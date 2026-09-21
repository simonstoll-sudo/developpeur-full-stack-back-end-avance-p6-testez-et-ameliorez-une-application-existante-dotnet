using PixelPion.Api.Models;

namespace PixelPion.Api.Data;

public interface IEmpruntRepository
{
    Task<Emprunt?> GetByIdAsync(int id);

    Task<List<Emprunt>> GetEnCoursByAbonneAsync(int abonneId);

    Task<Emprunt> AddAsync(Emprunt emprunt);

    Task UpdateAsync(Emprunt emprunt);
}
