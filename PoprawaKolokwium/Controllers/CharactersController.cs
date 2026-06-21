using Microsoft.AspNetCore.Mvc;
using PoprawaKolokwium.Exceptions;
using PoprawaKolokwium.Services;

namespace PoprawaKolokwium.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CharactersController(ICharactersService charactersService) : ControllerBase
{
    [HttpGet("/{id:int}")]
    public async Task<IActionResult> FindCharacter([FromRoute] int id, [FromQuery] int titlesCount = 3)
    {
        try
        {
            return Ok(await charactersService.FindCharacter(id, titlesCount));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost("/{id:int}/backpack")]
    public async Task<IActionResult> AddItemsToBackpack([FromRoute] int id, [FromBody] ICollection<int> itemIds)
    {
        try
        {
            await charactersService.AddItemToBackpack(id, itemIds);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (MaxWeightExceededException e)
        {
            return BadRequest(e.Message);
        }
    }
}