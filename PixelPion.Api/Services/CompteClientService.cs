using Microsoft.EntityFrameworkCore;
using PixelPion.Api.Data;
using PixelPion.Api.Models;

namespace PixelPion.Api.Services;

public class CompteClientService : ICompteClientService
{
    private readonly AppDbContext _context;

    public CompteClientService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Abonne> CreerCompteAsync(Abonne abonne)
    {
        if (string.IsNullOrWhiteSpace(abonne.Email))
        {
            throw new ArgumentException("L'adresse e-mail est obligatoire.", nameof(abonne));
        }

        if (string.IsNullOrWhiteSpace(abonne.MotDePasse))
        {
            throw new ArgumentException("Le mot de passe est obligatoire.", nameof(abonne));
        }

        var emailDejaUtilise = await _context.Abonnes
            .AnyAsync(a => a.Email == abonne.Email);

        if (emailDejaUtilise)
        {
            throw new InvalidOperationException($"L'adresse e-mail « {abonne.Email} » est déjà utilisée.");
        }

        abonne.DateInscription = DateTime.UtcNow;

        _context.Abonnes.Add(abonne);
        await _context.SaveChangesAsync();

        return abonne;
    }

    public async Task<Abonne?> ConsulterProfilAsync(int abonneId)
    {
        return await _context.Abonnes.FindAsync(abonneId);
    }

    public async Task<List<Emprunt>> ConsulterHistoriqueAsync(int abonneId)
    {
        var abonneExiste = await _context.Abonnes.AnyAsync(a => a.Id == abonneId);

        if (!abonneExiste)
        {
            throw new InvalidOperationException($"Aucun abonné trouvé avec l'identifiant {abonneId}.");
        }

        return await _context.Emprunts
            .Where(e => e.AbonneId == abonneId)
            .Include(e => e.Jeu)
            .OrderByDescending(e => e.DateEmprunt)
            .ToListAsync();
    }
}
