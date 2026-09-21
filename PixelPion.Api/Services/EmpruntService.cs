using PixelPion.Api.Data;
using PixelPion.Api.Models;

namespace PixelPion.Api.Services;

public class EmpruntService : IEmpruntService
{
    public const int QuotaMax = 3;

    private readonly IEmpruntRepository _empruntRepository;
    private readonly IJeuRepository _jeuRepository;
    private readonly IAbonneRepository _abonneRepository;

    public EmpruntService(
        IEmpruntRepository empruntRepository,
        IJeuRepository jeuRepository,
        IAbonneRepository abonneRepository)
    {
        _empruntRepository = empruntRepository;
        _jeuRepository = jeuRepository;
        _abonneRepository = abonneRepository;
    }

    public async Task<Emprunt> CreerEmpruntAsync(int abonneId, int jeuId)
    {
        var abonne = await _abonneRepository.GetByIdAsync(abonneId);

        if (abonne is null)
        {
            throw new InvalidOperationException($"Aucun abonné trouvé avec l'identifiant {abonneId}.");
        }

        var jeu = await _jeuRepository.GetByIdAsync(jeuId);

        if (jeu is null)
        {
            throw new InvalidOperationException($"Aucun jeu trouvé avec l'identifiant {jeuId}.");
        }

        if (jeu.StockDisponible <= 0)
        {
            throw new InvalidOperationException($"Aucun exemplaire disponible pour le jeu « {jeu.Titre} ».");
        }

        var emprunt = new Emprunt
        {
            AbonneId = abonneId,
            JeuId = jeuId,
            DateEmprunt = DateTime.UtcNow,
            DateRetour = null
        };

        jeu.StockDisponible--;
        await _jeuRepository.UpdateAsync(jeu);

        return await _empruntRepository.AddAsync(emprunt);
    }

    public async Task<Emprunt> RendreEmpruntAsync(int empruntId)
    {
        var emprunt = await _empruntRepository.GetByIdAsync(empruntId);

        if (emprunt is null)
        {
            throw new InvalidOperationException($"Aucun emprunt trouvé avec l'identifiant {empruntId}.");
        }

        var jeu = await _jeuRepository.GetByIdAsync(emprunt.JeuId);

        if (jeu is null)
        {
            throw new InvalidOperationException($"Aucun jeu trouvé avec l'identifiant {emprunt.JeuId}.");
        }

        emprunt.DateRetour = DateTime.UtcNow;
        await _empruntRepository.UpdateAsync(emprunt);

        jeu.StockDisponible++;
        await _jeuRepository.UpdateAsync(jeu);

        return emprunt;
    }
}
