using Adotion.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adotion.Data.Mappings;

public class AdotanteMapping : IEntityTypeConfiguration<Adotante>
{
    public void Configure(EntityTypeBuilder<Adotante> builder)
    {
        builder.HasKey(a=>a.Id);
        
        builder.Property(a=>a.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.Property(a => a.Sobrenome)
            .IsRequired()
            .HasColumnType("varchar(100)");
        
        builder.Property(a=>a.Email)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder.HasOne<Endereco>(a => a.Endereco)
            .WithOne(b => b.Adotante)
            .HasForeignKey<Endereco>(a=>a.AdotanteId).OnDelete(DeleteBehavior.Cascade); 
        
        builder.HasMany(a=>a.Animais)
            .WithOne(e => e.Adotante)
            .HasForeignKey(a=>a.AdotanteId);
        
        builder.ToTable("Adotantes");

    }
}