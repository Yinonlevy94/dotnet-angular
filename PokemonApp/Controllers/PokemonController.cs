using Microsoft.AspNetCore.Mvc;
using PokemonApp.DTOs;
using PokemonApp.Services;

namespace PokemonApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : ControllerBase
{
    private readonly PokemonService _pokemonService;

    public PokemonController(PokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetMonByID(int id)
    {
        var dto = _pokemonService.GetMonByID(id);
        if (dto == null) return NotFound();
        return Ok(dto);
    }
    
    [HttpPost]
    public IActionResult CreateMon(CreatePokemonRequest request)
    {
        var dto = _pokemonService.CreateMon(request);
        if (dto == null) return BadRequest();
        return Ok(dto);
    }

    [HttpPost("{pokemonId}/assign/{trainerId}")]
    public IActionResult AssignToTrainer(int pokemonId, int trainerId)
    {
        if (_pokemonService.AddMonToTrainer(pokemonId, trainerId))
            return Ok();
        return BadRequest();
    }
    
    [HttpGet("test-error")]
    public IActionResult TestError()
    {
        throw new Exception("This is a test error!");
    }

    [HttpGet("test-notfound")]
    public IActionResult TestNotFound()
    {
        throw new KeyNotFoundException("Pokemon not found!");
    }

    [HttpGet("test-badrequest")]
    public IActionResult TestBadRequest()
    {
        throw new ArgumentException("Invalid Pokemon ID!");
    }
}