using PokemonApp.Models;

namespace PokemonApp.Data;

public class DbSeed
{
    public static void SeedDb(PokemonDbContext context)
    {
        // checking if already seeded
        if (context.Owners.Any()) return;
        
        //need to start with counties, since they're the ones without any dependancy
        var kanto = new County ("Kanto" );
        var johto = new County ("Johto" );
        var hoenn = new County ("Hoenn" );
        context.Counties.AddRange(kanto, johto, hoenn);
        context.SaveChanges();

        
        var pokeball = new Item { Name = "Pokeball", Description = "Standard catching device" };
        var potion = new Item { Name = "Potion", Description = "Restores 20 HP" };
        var rare_candy = new Item { Name = "Rare Candy", Description = "Levels up Pokemon" };
        context.Items.AddRange(pokeball, potion, rare_candy);
        context.SaveChanges();

        
        var ash = new Owner { Name = "Ash Ketchum", Origin = kanto };
        var misty = new Owner { Name = "Misty", Origin = kanto };
        var brock = new Owner { Name = "Brock", Origin = kanto };
        context.Owners.AddRange(ash, misty, brock);
        context.SaveChanges();

        
        var pikachu = new Pokemon 
        { 
            Name = "Pikachu", 
            Type1 = PokemonType.Electric, 
            Level = 55, 
            Owner = "ash", 
        };
        
        var charizard = new Pokemon 
        { 
            Name = "Charizard", 
            Type1 = PokemonType.Fire, 
            Type2 = PokemonType.Flying, 
            Level = 65, 
            Owner = "ash", 
        };

        
        var starmie = new Pokemon 
        { 
            Name = "Starmie", 
            Type1 = PokemonType.Water, 
            Type2 = PokemonType.Psychic, 
            Level = 50, 
            Owner = "misty", 
        };

        
        var onix = new Pokemon 
        { 
            Name = "Onix", 
            Type1 = PokemonType.Rock, 
            Type2 = PokemonType.Ground, 
            Level = 48, 
            Owner = "brock", 
        };

        context.Pokemons.AddRange(pikachu, charizard, starmie, onix);
        context.SaveChanges();
    }
    
}