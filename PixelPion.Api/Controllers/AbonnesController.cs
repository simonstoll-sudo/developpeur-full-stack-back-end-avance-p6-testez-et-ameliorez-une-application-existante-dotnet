using Microsoft.AspNetCore.Mvc;
using PixelPion.Api.Models;
using PixelPion.Api.Services;

namespace PixelPion.Api.Controllers;

[ApiController]
[Route("api/abonnes")]
public class AbonnesController : ControllerBase
{
    private readonly ICompteClientService _compteClientService;

    public AbonnesController(ICompteClientService compteClientService)
    {
        _compteClientService = compteClientService;
    }

    [HttpPost]
    public async Task<IActionResult> CreerCompte([FromBody] Abonne abonne)
    {
        try
        {
            var cree = await _compteClientService.CreerCompteAsync(abonne);
            return CreatedAtAction(nameof(ConsulterProfil), new { id = cree.Id }, cree);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ConsulterProfil(int id)
    {
        var abonne = await _compteClientService.ConsulterProfilAsync(id);

        if (abonne is null)
        {
            return NotFound(new { message = $"Aucun abonné trouvé avec l'identifiant {id}." });
        }

        return Ok(abonne);
    }

    [HttpGet("{id}/emprunts")]
    public async Task<IActionResult> ConsulterHistorique(int id)
    {
        try
        {
            var emprunts = await _compteClientService.ConsulterHistoriqueAsync(id);
            return Ok(emprunts);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
