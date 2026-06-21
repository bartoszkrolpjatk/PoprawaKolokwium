using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoprawaKolokwium.Entities;

namespace PoprawaKolokwium.Configurations;

public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.HasKey(e => e.CharacterId);
        builder.Property(e => e.FirstName)
            .HasMaxLength(50);
        builder.Property(e => e.LastName)
            .HasMaxLength(120);

        builder.ToTable("Character");

        // builder.HasData(new List<Character>
        // {
        //     new ()
        //     {
        //         CharacterId = 1,
        //         FirstName = "Michael",
        //         LastName = "Scott",
        //         CurrentWeight = 4,
        //         MaxWeight = 10
        //     },
        //     new ()
        //     {
        //         CharacterId = 2,
        //         FirstName = "Michael",
        //         LastName = "Scott",
        //         CurrentWeight = 4,
        //         MaxWeight = 10
        //     }
        // });
    }
}