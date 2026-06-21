using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoprawaKolokwium.Entities;

namespace PoprawaKolokwium.Configurations;

public class TitleConfiguration : IEntityTypeConfiguration<Title>
{
    public void Configure(EntityTypeBuilder<Title> builder)
    {
        builder.HasKey(e => e.TitleId);
        builder.Property(e => e.TitleId)
            .HasMaxLength(100);
        builder.ToTable("Title");
        
        // builder.HasData(new List<Title>
        // {
        //     new()
        //     {
        //         TitleId = 1,
        //         Name = "Mag"
        //     },
        //     new()
        //     {
        //         TitleId = 2,
        //         Name = "Paladyn"
        //     },
        //     new()
        //     {
        //         TitleId = 3,
        //         Name = "Wojownik"
        //     },
        // });
    }
}