using PixelPion.Api.Models;

namespace PixelPion.Api.Data;

public interface IAbonneRepository
{
    Task<Abonne?> GetByIdAsync(int id);

    Task<Abonne?> GetByEmailAsync(string email);

    Task<Abonne> AddAsync(Abonne abonne);

    Task<List<Emprunt>> GetEmpruntsAsync(int abonneId);
}
