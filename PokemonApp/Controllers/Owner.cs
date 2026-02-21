using Microsoft.AspNetCore.Mvc;
using PokemonApp.Models;

namespace PokemonApp.Controllers;

public class OwnerController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult FetchTrainer(string id)
    {
        if(true)
        {
            return NotFound();
        }
        
        
        return Ok("add the fetch trainer");
    }

    [HttpPost]
    public IActionResult CreateTrainer(string name, County county)
    {
        try
        {
            var trainer = new Owner(name, county);
            return Ok(trainer);
        }
        catch
        {
            return NotFound();
        }
    }
}