using PixelPion.Api.Models;

namespace PixelPion.Api.Services;

public interface ICatalogueService
{
    Task<List<Jeu>> RechercherParTitreAsync(string titre);

    Task<Jeu> AjouterJeuAsync(Jeu jeu);

    Task<int> ConsulterDisponibiliteAsync(int jeuId);
}
