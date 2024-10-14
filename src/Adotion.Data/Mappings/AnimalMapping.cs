using Adotion.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adotion.Data.Mappings;

public class AnimalMapping : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(a => a.Especie)
            .IsRequired()
            .HasColumnType("varchar(100)");
            
        builder.Property(a => a.Raca)
            .IsRequired()
            .HasColumnType("varchar(100)");
        
        builder.Property(a=>a.Imagem)
            .HasColumnType("varchar(1000)");
        
        builder.Property(a => a.Descricao)
            .HasColumnType("varchar(1500)");

        builder.ToTable("Animais");
    }
}