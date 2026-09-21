using Microsoft.AspNetCore.Mvc;
using PixelPion.Api.Models;
using PixelPion.Api.Services;

namespace PixelPion.Api.Controllers;

[ApiController]
[Route("api/jeux")]
public class JeuxController : ControllerBase
{
    private readonly ICatalogueService _catalogueService;

    public JeuxController(ICatalogueService catalogueService)
    {
        _catalogueService = catalogueService;
    }

    [HttpGet]
    public async Task<IActionResult> Rechercher([FromQuery] string titre = "")
    {
        try
        {
            var jeux = await _catalogueService.RechercherParTitreAsync(titre);
            return Ok(jeux);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> AjouterJeu([FromBody] Jeu jeu)
    {
        try
        {
            var cree = await _catalogueService.AjouterJeuAsync(jeu);
            return CreatedAtAction(nameof(ConsulterDisponibilite), new { id = cree.Id }, cree);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}/disponibilite")]
    public async Task<IActionResult> ConsulterDisponibilite(int id)
    {
        try
        {
            var stockDisponible = await _catalogueService.ConsulterDisponibiliteAsync(id);
            return Ok(new { jeuId = id, stockDisponible });
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
