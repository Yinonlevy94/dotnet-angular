using Microsoft.AspNetCore.Mvc;
using PokemonApp.Data;
using PokemonApp.Models;

namespace PokemonApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnerController : ControllerBase
{
    
    private readonly PokemonDbContext  _pokemonDbContext;

    public OwnerController(PokemonDbContext pokemonDbContext)
    {
        _pokemonDbContext = pokemonDbContext;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetTrainerByID(int id)
    {
        var trainer = _pokemonDbContext.Owners.Find(id);
        if (trainer == null) return NotFound("trainer does not exists");
        return Ok(trainer);
    }

    [HttpPost("create-trainer")]
    public IActionResult CreateTrainer(string name, County county)
    {
        try
        {
            var dupTrainer = _pokemonDbContext.Owners.FirstOrDefault(t => t.Name == name);
            if (dupTrainer == null)
            {
                var trainer = new Owner(name, county);
                _pokemonDbContext.Owners.Add(trainer);
                _pokemonDbContext.SaveChanges();
                return Ok(trainer);
            }
            
            return NotFound("duplicate trainer");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}