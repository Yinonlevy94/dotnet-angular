using PokemonApp.Models;

namespace PokemonApp.Data;
using Microsoft.EntityFrameworkCore;

public class PokemonDbContext: DbContext
{
    public DbSet<Owner>  Owners { get; set; }
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<County> Counties { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Attack> Attacks { get; set; }

    public PokemonDbContext( DbContextOptions<PokemonDbContext> options) : base(options)
    {
       
        
    }
}