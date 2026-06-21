namespace PoprawaKolokwium.Dtos;

public class CharacterDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    
    public ICollection<ItemDto> BackpackItems { get; set; } = [];
    public ICollection<TitleDto> Titles { get; set; } = [];
}