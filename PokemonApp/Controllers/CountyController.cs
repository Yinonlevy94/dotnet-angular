using Microsoft.AspNetCore.Mvc;
using PokemonApp.DTOs;
using PokemonApp.Services;

namespace PokemonApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountyController : ControllerBase
{
    private readonly CountyService _countyService;

    public CountyController(CountyService countyService)
    {
        _countyService = countyService;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var dto = _countyService.GetById(id);
        if (dto == null) return NotFound();
        return Ok(dto);
    }
    
    [HttpPost]
    public IActionResult Create(CreateCountyRequest request)
    {
        var dto = _countyService.CreateCounty(request);
        if (dto == null) return BadRequest("County already exists");
        return Ok(dto);
    }
}