using Microsoft.AspNetCore.Mvc;
using PokemonApp.DTOs;
using PokemonApp.Services;

namespace PokemonApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnerController : ControllerBase
{
    private readonly OwnerService _ownerService;

    public OwnerController(OwnerService ownerService)
    {
        _ownerService = ownerService;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var dto = _ownerService.GetTrainerById(id);
        if (dto == null) return NotFound();
        return Ok(dto);
    }
    
    [HttpPost]
    public IActionResult Create(CreateOwnerRequest request)
    {
        var dto = _ownerService.CreateTrainer(request);
        if (dto == null) return BadRequest();
        return Ok(dto);
    }
    
    [HttpGet]
    public IActionResult GetByName([FromQuery] string name)
    {
        var owner = _ownerService.GetTrainerByName(name);
        if (owner == null) return NotFound();
        return Ok(owner);
    }
}