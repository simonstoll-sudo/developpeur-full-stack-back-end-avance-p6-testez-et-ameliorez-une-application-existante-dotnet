using PixelPion.Api.Data;
using PixelPion.Api.Models;

namespace PixelPion.Api.Services;

public class CatalogueService : ICatalogueService
{
    private readonly IJeuRepository _jeuRepository;

    public CatalogueService(IJeuRepository jeuRepository)
    {
        _jeuRepository = jeuRepository;
    }

    public async Task<List<Jeu>> RechercherParTitreAsync(string titre)
    {
        if (string.IsNullOrWhiteSpace(titre))
        {
            throw new ArgumentException("Le titre recherché ne peut pas être vide.", nameof(titre));
        }

        return await _jeuRepository.SearchByTitreAsync(titre.Trim());
    }

    public async Task<Jeu> AjouterJeuAsync(Jeu jeu)
    {
        if (string.IsNullOrWhiteSpace(jeu.Titre))
        {
            throw new ArgumentException("Le titre du jeu est obligatoire.", nameof(jeu));
        }

        if (jeu.StockTotal <= 0)
        {
            throw new ArgumentException("Le stock initial doit être strictement positif.", nameof(jeu));
        }

        jeu.StockDisponible = jeu.StockTotal;

        return await _jeuRepository.AddAsync(jeu);
    }

    public async Task<int> ConsulterDisponibiliteAsync(int jeuId)
    {
        var jeu = await _jeuRepository.GetByIdAsync(jeuId);

        if (jeu is null)
        {
            throw new InvalidOperationException($"Aucun jeu trouvé avec l'identifiant {jeuId}.");
        }

        return jeu.StockDisponible;
    }
}
