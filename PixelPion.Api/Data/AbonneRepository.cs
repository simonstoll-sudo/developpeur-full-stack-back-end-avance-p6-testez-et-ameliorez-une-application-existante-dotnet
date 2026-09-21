using Microsoft.EntityFrameworkCore;
using PixelPion.Api.Models;

namespace PixelPion.Api.Data;

public class AbonneRepository : IAbonneRepository
{
    private readonly AppDbContext _context;

    public AbonneRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Abonne?> GetByIdAsync(int id)
    {
        return await _context.Abonnes.FindAsync(id);
    }

    public async Task<Abonne?> GetByEmailAsync(string email)
    {
        return await _context.Abonnes.FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<Abonne> AddAsync(Abonne abonne)
    {
        _context.Abonnes.Add(abonne);
        await _context.SaveChangesAsync();
        return abonne;
    }

    public async Task<List<Emprunt>> GetEmpruntsAsync(int abonneId)
    {
        return await _context.Emprunts
            .Where(e => e.AbonneId == abonneId)
            .Include(e => e.Jeu)
            .OrderByDescending(e => e.DateEmprunt)
            .ToListAsync();
    }
}
