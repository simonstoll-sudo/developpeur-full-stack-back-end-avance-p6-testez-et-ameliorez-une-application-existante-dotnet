using PixelPion.Api.Models;

namespace PixelPion.Api.Services;

public interface IEmpruntService
{
    Task<Emprunt> CreerEmpruntAsync(int abonneId, int jeuId);

    Task<Emprunt> RendreEmpruntAsync(int empruntId);
}
