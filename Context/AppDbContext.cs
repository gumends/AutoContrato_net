using AutoContrato_net.Model;
using Microsoft.EntityFrameworkCore;

namespace AutoContrato_net.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Proprietario> Proprietarios { get; set; }

    public DbSet<Propriedade> Propriedades { get; set; }

    public DbSet<Locatario> Locatarios { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Propriedade>()
            .HasOne(p => p.Proprietario)
            .WithMany(pr => pr.Propriedades)
            .HasForeignKey(p => p.ProprietarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Locatario>()
            .HasOne(l => l.Propriedade)
            .WithOne(p => p.Locatario)
            .HasForeignKey<Locatario>(l => l.PropriedadeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
