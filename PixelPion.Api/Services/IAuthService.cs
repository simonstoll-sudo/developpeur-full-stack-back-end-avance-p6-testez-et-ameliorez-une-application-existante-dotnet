using PixelPion.Api.Models;

namespace PixelPion.Api.Services;

public interface IAuthService
{
    Task<Abonne?> ConnecterAsync(string email, string motDePasse);
}
