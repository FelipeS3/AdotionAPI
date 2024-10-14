using Adotion.Business.Models;
using Microsoft.EntityFrameworkCore;


namespace Adotion.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Adotante> Adotantes  { get; set; }
    public DbSet<Animal> Animais { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.ClrType == typeof(string))
            .ToList()
            .ForEach(p => p.SetColumnType("varchar(100)"));
        
        
        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e
                         .GetForeignKeys())) relationship
                               .DeleteBehavior = DeleteBehavior.ClientSetNull;
        
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}