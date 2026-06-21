namespace PoprawaKolokwium.Entities;

public class Backpack
{
    public int CharacterId { get; set; }
    public int ItemId { get; set; }
    public int Amount { get; set; }

    public Item Item { get; set; } = null!;
    public Character Character { get; set; } = null!;
}