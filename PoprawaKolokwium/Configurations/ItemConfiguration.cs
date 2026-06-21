using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoprawaKolokwium.Entities;

namespace PoprawaKolokwium.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(e => e.ItemId);
        builder.Property(e => e.Name)
            .HasMaxLength(100);
        
        builder.ToTable("Item");

        // builder.HasData(new List<Item>
        // {
        //
        // });
    }
}