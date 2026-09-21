using Microsoft.AspNetCore.Mvc;
using PixelPion.Api.Services;

namespace PixelPion.Api.Controllers;

public record CreerEmpruntRequest(int AbonneId, int JeuId);

[ApiController]
[Route("api/emprunts")]
public class EmpruntsController : ControllerBase
{
    private readonly IEmpruntService _empruntService;

    public EmpruntsController(IEmpruntService empruntService)
    {
        _empruntService = empruntService;
    }

    [HttpPost]
    public async Task<IActionResult> CreerEmprunt([FromBody] CreerEmpruntRequest request)
    {
        try
        {
            var emprunt = await _empruntService.CreerEmpruntAsync(request.AbonneId, request.JeuId);
            return StatusCode(StatusCodes.Status201Created, emprunt);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("{id}/retour")]
    public async Task<IActionResult> RendreEmprunt(int id)
    {
        try
        {
            var emprunt = await _empruntService.RendreEmpruntAsync(id);
            return Ok(emprunt);
        }
        catch (InvalidOperationException ex)
        {
            if (ex.Message.Contains("Aucun emprunt"))
            {
                return NotFound(new { message = ex.Message });
            }

            return BadRequest(new { message = ex.Message });
        }
    }
}
