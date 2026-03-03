using Microsoft.EntityFrameworkCore;
using PokemonApp.Data;
using PokemonApp.Models;
using PokemonApp.DTOs;

namespace PokemonApp.Services;

public class PokemonService
{
    private readonly PokemonDbContext _context;
    
    public PokemonService(PokemonDbContext context)
    {
        _context = context;
    }

    public PokemonDTO? GetMonByID(int id)
    {
        var pokemon = _context.Pokemons
            .Include(p => p.Owner)
            .Include(p => p.Attacks)
            .Include(p => p.HeldItem)
            .FirstOrDefault(x => x.Id == id);
        
        if (pokemon == null) return null;
        
        return new PokemonDTO
        {
            Id = pokemon.Id,
            Name = pokemon.Name,
            Type1 = pokemon.Type1,
            Type2 = pokemon.Type2,
            Level = pokemon.Level,
            OwnerId = pokemon.Owner?.Id,
            OwnerName = pokemon.Owner?.Name,
            AttackNames = pokemon.Attacks?.Select(a => a.Name).ToList(),
            HeldItemName = pokemon.HeldItem?.Name
        };
    }

    public PokemonDTO? CreateMon(CreatePokemonRequest request)
    {
        Owner? owner = null;
        if (request.OwnerId.HasValue)
        {
            owner = _context.Owners.Find(request.OwnerId.Value);
            if (owner == null) return null;
        }
        
        var pokemon = new Pokemon(
            request.Name,
            request.Type1,
            request.Type2,
            request.Level
        )
        {
            Owner = owner,
            OwnerId = owner?.Id
        };
        
        _context.Pokemons.Add(pokemon);
        _context.SaveChanges();
        
        return new PokemonDTO
        {
            Id = pokemon.Id,
            Name = pokemon.Name,
            Type1 = pokemon.Type1,
            Type2 = pokemon.Type2,
            Level = pokemon.Level,
            OwnerId = pokemon.Owner?.Id,
            OwnerName = pokemon.Owner?.Name
        };
    }

    public bool AddMonToTrainer(int monId, int trainerId)
    {
        var pokemon = _context.Pokemons.Find(monId);
        var trainer = _context.Owners.Find(trainerId);
        
        if (pokemon == null || trainer == null) return false;
        
        pokemon.Owner = trainer;
        pokemon.OwnerId = trainerId;
        _context.SaveChanges();
        return true;
    }
}