using Microsoft.AspNetCore.Mvc;
using PokemonApp.Data;
using PokemonApp.Models;

namespace PokemonApp.Controllers;

public class CountyController : ControllerBase
{
    private readonly PokemonDbContext  _pokemonDbContext;

    public CountyController(PokemonDbContext pokemonDbContext)
    {
        _pokemonDbContext = pokemonDbContext;
    }
    [HttpPost ("create-county")]
    public IActionResult CreateCounty(string name)
    {
        try
        {
            var dupCounty = _pokemonDbContext.Counties.FirstOrDefault(c => c.name == name);
            if (dupCounty != null) return NotFound("duplicate county name");
            var newCounty = new County(name);
            _pokemonDbContext.Counties.Add(newCounty);
            _pokemonDbContext.SaveChanges();
            return Ok(newCounty);
        } catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}