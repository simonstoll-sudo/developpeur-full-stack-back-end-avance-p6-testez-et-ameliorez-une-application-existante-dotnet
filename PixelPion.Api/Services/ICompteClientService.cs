using PixelPion.Api.Models;

namespace PixelPion.Api.Services;

public interface ICompteClientService
{
    Task<Abonne> CreerCompteAsync(Abonne abonne);

    Task<Abonne?> ConsulterProfilAsync(int abonneId);

    Task<List<Emprunt>> ConsulterHistoriqueAsync(int abonneId);
}
