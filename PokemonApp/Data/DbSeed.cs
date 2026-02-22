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

        
        var pokeball = new Item { name = "Pokeball", description = "Standard catching device" };
        var potion = new Item { name = "Potion", description = "Restores 20 HP" };
        var rare_candy = new Item { name = "Rare Candy", description = "Levels up Pokemon" };
        context.Items.AddRange(pokeball, potion, rare_candy);
        context.SaveChanges();

        
        var ash = new Owner { name = "Ash Ketchum", origin = kanto };
        var misty = new Owner { name = "Misty", origin = kanto };
        var brock = new Owner { name = "Brock", origin = kanto };
        context.Owners.AddRange(ash, misty, brock);
        context.SaveChanges();

        
        var pikachu = new Pokemon 
        { 
            name = "Pikachu", 
            type1 = PokemonType.Electric, 
            level = 55, 
            owner = "ash", 
        };
        
        var charizard = new Pokemon 
        { 
            name = "Charizard", 
            type1 = PokemonType.Fire, 
            type2 = PokemonType.Flying, 
            level = 65, 
            owner = "ash", 
        };

        
        var starmie = new Pokemon 
        { 
            name = "Starmie", 
            type1 = PokemonType.Water, 
            type2 = PokemonType.Psychic, 
            level = 50, 
            owner = "misty", 
        };

        
        var onix = new Pokemon 
        { 
            name = "Onix", 
            type1 = PokemonType.Rock, 
            type2 = PokemonType.Ground, 
            level = 48, 
            owner = "brock", 
        };

        context.Pokemons.AddRange(pikachu, charizard, starmie, onix);
        context.SaveChanges();
    }
    
}