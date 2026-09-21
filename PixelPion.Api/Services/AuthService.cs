using PixelPion.Api.Data;
using PixelPion.Api.Models;

namespace PixelPion.Api.Services;

public class AuthService : IAuthService
{
    private readonly IAbonneRepository _abonneRepository;
    private readonly ILogger<AuthService> _logger;

    public AuthService(IAbonneRepository abonneRepository, ILogger<AuthService> logger)
    {
        _abonneRepository = abonneRepository;
        _logger = logger;
    }

    public async Task<Abonne?> ConnecterAsync(string email, string motDePasse)
    {
        _logger.LogInformation("Tentative de connexion : email={Email}, motDePasse={MotDePasse}", email, motDePasse);

        var abonne = await _abonneRepository.GetByEmailAsync(email);

        if (abonne is null)
        {
            return null;
        }

        if (abonne.MotDePasse == motDePasse)
        {
            _logger.LogInformation("Connexion réussie pour {Email}", email);
            return abonne;
        }

        return null;
    }
}
