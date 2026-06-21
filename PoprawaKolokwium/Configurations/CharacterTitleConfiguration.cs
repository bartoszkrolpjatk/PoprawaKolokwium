using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoprawaKolokwium.Entities;

namespace PoprawaKolokwium.Configurations;

public class CharacterTitleConfiguration : IEntityTypeConfiguration<CharacterTitle>
{
    public void Configure(EntityTypeBuilder<CharacterTitle> builder)
    {
        builder.HasKey(e => new { e.CharacterId, e.TitleId });
        builder.HasOne(e => e.Character)
            .WithMany(e => e.CharacterTitles)
            .HasForeignKey(e => e.CharacterId);
        builder.HasOne(e => e.Title)
            .WithMany(e => e.CharacterTitles)
            .HasForeignKey(e => e.TitleId);
        builder.ToTable("Character_Title");
        
        // builder.HasData(new List<CharacterTitle>
        // {
        //     
        // });
    }
}