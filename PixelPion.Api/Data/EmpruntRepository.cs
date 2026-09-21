using Microsoft.EntityFrameworkCore;
using PixelPion.Api.Models;

namespace PixelPion.Api.Data;

public class EmpruntRepository : IEmpruntRepository
{
    private readonly AppDbContext _context;

    public EmpruntRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Emprunt?> GetByIdAsync(int id)
    {
        return await _context.Emprunts.FindAsync(id);
    }

    public async Task<List<Emprunt>> GetEnCoursByAbonneAsync(int abonneId)
    {
        return await _context.Emprunts
            .Where(e => e.AbonneId == abonneId && e.DateRetour == null)
            .ToListAsync();
    }

    public async Task<Emprunt> AddAsync(Emprunt emprunt)
    {
        _context.Emprunts.Add(emprunt);
        await _context.SaveChangesAsync();
        return emprunt;
    }

    public async Task UpdateAsync(Emprunt emprunt)
    {
        _context.Emprunts.Update(emprunt);
        await _context.SaveChangesAsync();
    }
}
