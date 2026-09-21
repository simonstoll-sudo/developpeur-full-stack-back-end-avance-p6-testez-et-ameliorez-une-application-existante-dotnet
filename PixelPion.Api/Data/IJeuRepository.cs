using PixelPion.Api.Models;

namespace PixelPion.Api.Data;

public interface IJeuRepository
{
    Task<Jeu?> GetByIdAsync(int id);

    Task<List<Jeu>> SearchByTitreAsync(string titre);

    Task<Jeu> AddAsync(Jeu jeu);

    Task UpdateAsync(Jeu jeu);
}
