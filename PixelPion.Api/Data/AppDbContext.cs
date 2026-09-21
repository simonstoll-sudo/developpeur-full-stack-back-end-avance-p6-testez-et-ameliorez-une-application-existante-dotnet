using Microsoft.EntityFrameworkCore;
using PixelPion.Api.Models;

namespace PixelPion.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Abonne> Abonnes => Set<Abonne>();

    public DbSet<Jeu> Jeux => Set<Jeu>();

    public DbSet<Emprunt> Emprunts => Set<Emprunt>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Abonne>()
            .HasIndex(a => a.Email)
            .IsUnique();

        modelBuilder.Entity<Emprunt>()
            .HasOne(e => e.Abonne)
            .WithMany(a => a.Emprunts)
            .HasForeignKey(e => e.AbonneId);

        modelBuilder.Entity<Emprunt>()
            .HasOne(e => e.Jeu)
            .WithMany(j => j.Emprunts)
            .HasForeignKey(e => e.JeuId);
    }
}
