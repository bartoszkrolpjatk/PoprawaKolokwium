using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoprawaKolokwium.Entities;

namespace PoprawaKolokwium.Configurations;

public class BackpackConfiguration : IEntityTypeConfiguration<Backpack>
{
    public void Configure(EntityTypeBuilder<Backpack> builder)
    {
        builder.HasKey(e => new { e.ItemId, e.CharacterId });
        builder.HasOne(e => e.Character)
            .WithMany(e => e.Backpacks)
            .HasForeignKey(e => e.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Item)
            .WithMany(e => e.Backpacks)
            .HasForeignKey(e => e.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Backpack");
            
        // builder.HasData(new List<Backpack>
        // {
        //
        // });
    }
}