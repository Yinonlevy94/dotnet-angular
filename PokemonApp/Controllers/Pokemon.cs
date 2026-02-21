using Microsoft.AspNetCore.Mvc;
using PokemonApp.Models;
using PokemonApp.Data;

namespace PokemonApp.Controllers;

public class PokemonController : ControllerBase
{
    [HttpPost("create")]
    public IActionResult CreateMon(string name, PokemonType type1, PokemonType type2, int level, Item item)
    {
        try
        {
            var newMon = new Pokemon(name, type1, type2, level, item);
            return Ok(newMon);
        }
        catch
        {
            return NotFound();
        }
    }

    [HttpPost("add2trainer")]
    public IActionResult AddMon(Pokemon mon, Owner trainer)
    {
        try
        {
            mon.Owner = trainer;
            trainer.MonsList.Add(mon);
            return Ok();
        }
        catch
        {
            return NotFound();
        }

    }

    [HttpPut]
    public IActionResult UpdateAttacks(Pokemon mon, Attack a1, Attack a2, Attack a3, Attack a4)
    {
        try
        {
            var newMoves = mon._attacks;
            newMoves.Add(a1);
            newMoves.Add(a2);
            newMoves.Add(a3);
            newMoves.Add(a4);
            return Ok(mon._attacks = newMoves);
        }
        catch
        {
            return NotFound();
        }
    }
    
    
}