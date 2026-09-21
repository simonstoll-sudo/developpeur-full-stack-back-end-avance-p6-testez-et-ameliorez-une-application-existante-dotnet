using Microsoft.EntityFrameworkCore;
using PixelPion.Api.Models;

namespace PixelPion.Api.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Abonnes.AnyAsync())
        {
            return;
        }

        var abonnes = new List<Abonne>
        {
            new Abonne
            {
                Nom = "Camille Perrin",
                Email = "camille.perrin@example.com",
                MotDePasse = "azerty123",
                DateInscription = new DateTime(2023, 3, 12)
            },
            new Abonne
            {
                Nom = "Julien Morel",
                Email = "julien.morel@example.com",
                MotDePasse = "pixel2024",
                DateInscription = new DateTime(2023, 7, 4)
            },
            new Abonne
            {
                Nom = "Sarah Lambert",
                Email = "sarah.lambert@example.com",
                MotDePasse = "catan4ever",
                DateInscription = new DateTime(2024, 1, 21)
            },
            new Abonne
            {
                Nom = "Antoine Girard",
                Email = "antoine.girard@example.com",
                MotDePasse = "motdepasse",
                DateInscription = new DateTime(2024, 5, 9)
            }
        };

        var jeux = new List<Jeu>
        {
            new Jeu { Titre = "Les Colons de Catane", Type = "JeuDeSociete", StockTotal = 4, StockDisponible = 3 },
            new Jeu { Titre = "7 Wonders", Type = "JeuDeSociete", StockTotal = 3, StockDisponible = 3 },
            new Jeu { Titre = "Azul", Type = "JeuDeSociete", StockTotal = 2, StockDisponible = 1 },
            new Jeu { Titre = "Terraforming Mars", Type = "JeuDeSociete", StockTotal = 2, StockDisponible = 2 },
            new Jeu { Titre = "The Legend of Zelda: Tears of the Kingdom", Type = "JeuVideo", StockTotal = 3, StockDisponible = 2 },
            new Jeu { Titre = "Mario Kart 8 Deluxe", Type = "JeuVideo", StockTotal = 5, StockDisponible = 5 },
            new Jeu { Titre = "Hollow Knight", Type = "JeuVideo", StockTotal = 2, StockDisponible = 2 },
            new Jeu { Titre = "It Takes Two", Type = "JeuVideo", StockTotal = 2, StockDisponible = 2 }
        };

        context.Abonnes.AddRange(abonnes);
        context.Jeux.AddRange(jeux);
        await context.SaveChangesAsync();

        var emprunts = new List<Emprunt>
        {
            new Emprunt
            {
                AbonneId = abonnes[0].Id,
                JeuId = jeux[0].Id,
                DateEmprunt = DateTime.UtcNow.AddDays(-12),
                DateRetour = null
            },
            new Emprunt
            {
                AbonneId = abonnes[1].Id,
                JeuId = jeux[2].Id,
                DateEmprunt = DateTime.UtcNow.AddDays(-8),
                DateRetour = null
            },
            new Emprunt
            {
                AbonneId = abonnes[2].Id,
                JeuId = jeux[4].Id,
                DateEmprunt = DateTime.UtcNow.AddDays(-5),
                DateRetour = null
            },
            new Emprunt
            {
                AbonneId = abonnes[0].Id,
                JeuId = jeux[5].Id,
                DateEmprunt = DateTime.UtcNow.AddDays(-30),
                DateRetour = DateTime.UtcNow.AddDays(-16)
            },
            new Emprunt
            {
                AbonneId = abonnes[3].Id,
                JeuId = jeux[1].Id,
                DateEmprunt = DateTime.UtcNow.AddDays(-25),
                DateRetour = DateTime.UtcNow.AddDays(-20)
            }
        };

        context.Emprunts.AddRange(emprunts);
        await context.SaveChangesAsync();
    }
}
