using Microsoft.EntityFrameworkCore;
using PoprawaKolokwium.Data;
using PoprawaKolokwium.Dtos;
using PoprawaKolokwium.Entities;
using PoprawaKolokwium.Exceptions;

namespace PoprawaKolokwium.Services;

public class CharactersService(AppDbContext dbContext) : ICharactersService
{
    public async Task<CharacterDto> FindCharacter(int id, int titlesCount)
    {
        var character = await dbContext.Characters
            .Include(e => e.Backpacks)
            .Include(e => e.CharacterTitles)
            .ThenInclude(e => e.Title)
            .FirstOrDefaultAsync(c => c.CharacterId == id);
        if (character == null)
        {
            throw new NotFoundException($"Character not found by id: {id}");
        }

        return new CharacterDto()
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = character.Backpacks
                .Take(titlesCount)
                .Select(b =>
                    new ItemDto()
                    {
                        ItemName = b.Item.Name,
                        ItemWeight = b.Item.Weight,
                        Amount = b.Amount
                    })
                .ToList(),
            Titles = character.CharacterTitles
                .Select(ct => new TitleDto()
                {
                    Name = ct.Title.Name,
                    AcquiredAt = ct.AcquiredAt
                })
                .ToList()
        };
    }

    public async Task AddItemToBackpack(int id, ICollection<int> itemIds)
    {
        var transaction =  await dbContext.Database.BeginTransactionAsync();
        try
        {
            List<Item> itemsToAdd = [];
            foreach (var i in itemIds)
            {
                var itemToAdd = await dbContext.Items.FirstOrDefaultAsync(e => e.ItemId == i);
                if (itemToAdd == null)
                    throw new NotFoundException($"Item with id {i} not found");
                itemsToAdd.Add(itemToAdd);
            }

            var character = await dbContext.Characters.FirstOrDefaultAsync(e => e.CharacterId == id);
            if (character == null)
                throw new NotFoundException($"Character not found by id: {id}");

            if (character.CurrentWeight + itemsToAdd.Sum(i => i.Weight) > character.MaxWeight)
                throw new MaxWeightExceededException($"Max weight {character.MaxWeight} for character {id} exceeded");
            
            character.CurrentWeight += itemsToAdd.Sum(i => i.Weight); 
            await dbContext.SaveChangesAsync();

            foreach (var i in itemsToAdd)
            {
                await dbContext.Backpacks
                    .AddAsync(new Backpack()
                    {
                        Item = i,
                        Character = character,
                        Amount = 1
                    });
                await dbContext.SaveChangesAsync();
            }
            
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}