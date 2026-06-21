using PoprawaKolokwium.Dtos;

namespace PoprawaKolokwium.Services;

public interface ICharactersService
{
    public Task<CharacterDto> FindCharacter(int id, int titlesCount);
    public Task AddItemToBackpack(int id, ICollection<int> itemIds);
}