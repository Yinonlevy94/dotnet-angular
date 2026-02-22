using System.Data;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Models;
using PokemonApp.Data;

namespace PokemonApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : ControllerBase
{
    
    private readonly PokemonDbContext _pokemonDbContext;

    public PokemonController(PokemonDbContext pokemonDbContext)
    {
        _pokemonDbContext = pokemonDbContext;
    }
    [HttpGet("{id}")]
    public IActionResult GetMonByID(int id)
    {
        var targetMon = _pokemonDbContext.Pokemons.Find(id);
        if (targetMon == null) return NotFound("mon not found");
        return Ok(targetMon);
        
    }
    
    [HttpPost("create-mon")]
    public IActionResult CreateMon(string name, PokemonType type1, PokemonType type2, int level,int ownerId)
    {
        // try
        // {
            var exists = _pokemonDbContext.Pokemons.FirstOrDefault(p => p.name == name);
            if (exists != null) return BadRequest("Duplicate Pokemon");
            
            var owner = _pokemonDbContext.Owners.Find(ownerId);
            if (owner == null) return NotFound("Owner not found");
            
            var newMon = new Pokemon(name, type1, type2, level, owner.name);
            _pokemonDbContext.Add(newMon);
            _pokemonDbContext.SaveChanges();
            return Ok(newMon);
        // }
        // catch
        // {
            return NotFound("error");
        // }
    }

    [HttpPost("add-mon-2-trainer")]
    public IActionResult AddMon(int monID, int trainerID)
    {
        try
        {
            var trainer =_pokemonDbContext.Owners.Find(trainerID);
            var mon = _pokemonDbContext.Pokemons.Find(monID);
            if (mon == null || trainer == null) return NotFound("mon/trainer not found, supply a different one");
            var dupMon =trainer.monsList.Contains(mon);
            if (!dupMon)
            {
                trainer.monsList.Add(mon);
                _pokemonDbContext.SaveChanges();
                return Ok("added mon to trainer");
            }
            
            return NotFound("Trainer already has this mon");
        }
        catch
        {
            return NotFound("error");
        }

    }

    [HttpPut("update-attacks")]
    public IActionResult UpdateAttacks(int monID, List<Attack> attacks)
    {
        try
        {
            var mon = _pokemonDbContext.Pokemons.Find(monID);
            if (mon == null) return NotFound("mon does not exists");
            mon.attacks = attacks;
            _pokemonDbContext.SaveChanges();
            return Ok(attacks);
        }
        catch
        {
            return NotFound("error");
        }
    }

    
    
    
}