using Microsoft.EntityFrameworkCore;
using PixelPion.Api.Models;

namespace PixelPion.Api.Data;

public class JeuRepository : IJeuRepository
{
    private readonly AppDbContext _context;

    public JeuRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Jeu?> GetByIdAsync(int id)
    {
        return await _context.Jeux.FindAsync(id);
    }

    public async Task<List<Jeu>> SearchByTitreAsync(string titre)
    {
        return await _context.Jeux
            .Where(j => EF.Functions.Like(j.Titre, $"%{titre}%"))
            .OrderBy(j => j.Titre)
            .ToListAsync();
    }

    public async Task<Jeu> AddAsync(Jeu jeu)
    {
        _context.Jeux.Add(jeu);
        await _context.SaveChangesAsync();
        return jeu;
    }

    public async Task UpdateAsync(Jeu jeu)
    {
        _context.Jeux.Update(jeu);
        await _context.SaveChangesAsync();
    }
}
