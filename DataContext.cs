using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class DataContext : DbContext
{
    public DbSet<Contrato> Contratos { get; set; }
    public DbSet<Importacao> Importacoes { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contrato>()
            .ToTable("Contratos")
            .HasKey(c => c.Id); // Define a propriedade Id como a chave primária

        modelBuilder.Entity<Importacao>()
            .ToTable("Importacoes")
            .HasKey(i => i.Id); // Define a propriedade Id como a chave primária
    }
}
