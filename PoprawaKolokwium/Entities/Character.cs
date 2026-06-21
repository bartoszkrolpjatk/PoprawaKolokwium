namespace PoprawaKolokwium.Entities;

public class Character
{
    public int CharacterId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; } = [];
    public ICollection<CharacterTitle> CharacterTitles { get; set; } = [];
}