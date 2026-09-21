using Microsoft.AspNetCore.Mvc;
using PixelPion.Api.Services;

namespace PixelPion.Api.Controllers;

public record LoginRequest(string Email, string MotDePasse);

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var abonne = await _authService.ConnecterAsync(request.Email, request.MotDePasse);

        if (abonne is null)
        {
            return Unauthorized(new { message = "Identifiants invalides." });
        }

        return Ok(abonne);
    }
}
