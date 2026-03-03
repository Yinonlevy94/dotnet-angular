using PokemonApp.Models;

namespace PokemonApp.Data;

public class DbSeed
{
    public static void SeedDb(PokemonDbContext context)
    {
        // Check if already seeded
        if (context.Owners.Any()) return;
        
        // === ALL POKEMON REGIONS ===
        
        // Main Series Regions (9)
        var kanto = new County { Name = "Kanto" };
        var johto = new County { Name = "Johto" };
        var hoenn = new County { Name = "Hoenn" };
        var sinnoh = new County { Name = "Sinnoh" };
        var hisui = new County { Name = "Hisui" };
        var unova = new County { Name = "Unova" };
        var kalos = new County { Name = "Kalos" };
        var alola = new County { Name = "Alola" };
        var galar = new County { Name = "Galar" };
        var paldea = new County { Name = "Paldea" };
        
        // Spin-off Game Regions
        var orre = new County { Name = "Orre" };
        var fiore = new County { Name = "Fiore" };
        var almia = new County { Name = "Almia" };
        var oblivia = new County { Name = "Oblivia" };
        var ransei = new County { Name = "Ransei" };
        var ferrum = new County { Name = "Ferrum" };
        var pasio = new County { Name = "Pasio" };
        var lental = new County { Name = "Lental" };
        var aeos = new County { Name = "Aeos Island" };
        
        // Anime-only Region
        var orangeIslands = new County { Name = "Orange Islands" };
        
        context.Counties.AddRange(
            kanto, johto, hoenn, sinnoh, hisui, unova, kalos, alola, galar, paldea,
            orre, fiore, almia, oblivia, ransei, ferrum, pasio, lental, aeos,
            orangeIslands
        );
        context.SaveChanges();

        // === ITEMS ===
        var pokeball = new Item { Name = "Pokeball", Description = "Standard catching device" };
        var potion = new Item { Name = "Potion", Description = "Restores 20 HP" };
        var rareCandy = new Item { Name = "Rare Candy", Description = "Levels up Pokemon" };
        
        context.Items.AddRange(pokeball, potion, rareCandy);
        context.SaveChanges();

        // === OWNERS ===
        
        // Kanto Trainers
        var ash = new Owner { Name = "Ash Ketchum", Origin = kanto };
        var misty = new Owner { Name = "Misty", Origin = kanto };
        var brock = new Owner { Name = "Brock", Origin = kanto };
        
        // Johto Trainers
        var ethan = new Owner { Name = "Ethan", Origin = johto };
        var lyra = new Owner { Name = "Lyra", Origin = johto };
        var silver = new Owner { Name = "Silver", Origin = johto };
        
        // Hoenn Trainers
        var brendan = new Owner { Name = "Brendan", Origin = hoenn };
        var may = new Owner { Name = "May", Origin = hoenn };
        var steven = new Owner { Name = "Steven Stone", Origin = hoenn };
        
        // Sinnoh Trainers
        var lucas = new Owner { Name = "Lucas", Origin = sinnoh };
        var dawn = new Owner { Name = "Dawn", Origin = sinnoh };
        var cynthia = new Owner { Name = "Cynthia", Origin = sinnoh };
        
        // Hisui Trainers
        var rei = new Owner { Name = "Rei", Origin = hisui };
        var akari = new Owner { Name = "Akari", Origin = hisui };
        
        // Unova Trainers
        var hilbert = new Owner { Name = "Hilbert", Origin = unova };
        var hilda = new Owner { Name = "Hilda", Origin = unova };
        var nate = new Owner { Name = "Nate", Origin = unova };
        
        // Kalos Trainers
        var calem = new Owner { Name = "Calem", Origin = kalos };
        var serena = new Owner { Name = "Serena", Origin = kalos };
        var diantha = new Owner { Name = "Diantha", Origin = kalos };
        
        // Alola Trainers
        var elio = new Owner { Name = "Elio", Origin = alola };
        var selene = new Owner { Name = "Selene", Origin = alola };
        var hau = new Owner { Name = "Hau", Origin = alola };
        
        // Galar Trainers
        var victor = new Owner { Name = "Victor", Origin = galar };
        var gloria = new Owner { Name = "Gloria", Origin = galar };
        var leon = new Owner { Name = "Leon", Origin = galar };
        
        // Paldea Trainers
        var florian = new Owner { Name = "Florian", Origin = paldea };
        var juliana = new Owner { Name = "Juliana", Origin = paldea };
        var nemona = new Owner { Name = "Nemona", Origin = paldea };
        
        // Orre Trainers
        var wes = new Owner { Name = "Wes", Origin = orre };
        var michael = new Owner { Name = "Michael", Origin = orre };
        
        // Fiore Rangers
        var solana = new Owner { Name = "Solana", Origin = fiore };
        var lunick = new Owner { Name = "Lunick", Origin = fiore };
        
        // Almia Rangers
        var kate = new Owner { Name = "Kate", Origin = almia };
        var keith = new Owner { Name = "Keith", Origin = almia };
        
        // Oblivia Rangers
        var summer = new Owner { Name = "Summer", Origin = oblivia };
        var ben = new Owner { Name = "Ben", Origin = oblivia };
        
        // Ransei Warlords
        var nobunaga = new Owner { Name = "Nobunaga", Origin = ransei };
        var oichi = new Owner { Name = "Oichi", Origin = ransei };
        
        // Orange Islands Trainers
        var drake = new Owner { Name = "Drake", Origin = orangeIslands };
        var luana = new Owner { Name = "Luana", Origin = orangeIslands };
        
        context.Owners.AddRange(
            ash, misty, brock,
            ethan, lyra, silver,
            brendan, may, steven,
            lucas, dawn, cynthia,
            rei, akari,
            hilbert, hilda, nate,
            calem, serena, diantha,
            elio, selene, hau,
            victor, gloria, leon,
            florian, juliana, nemona,
            wes, michael,
            solana, lunick,
            kate, keith,
            summer, ben,
            nobunaga, oichi,
            drake, luana
        );
        context.SaveChanges();

        // === POKEMON (each trainer gets at least 1) ===
        
        // Kanto - Ash's team
        var pikachu = new Pokemon { Name = "Pikachu", Type1 = PokemonType.Electric, Level = 55, Owner = ash, OwnerId = ash.Id };
        var charizard = new Pokemon { Name = "Charizard", Type1 = PokemonType.Fire, Type2 = PokemonType.Flying, Level = 65, Owner = ash, OwnerId = ash.Id };
        
        // Kanto - Misty's team
        var starmie = new Pokemon { Name = "Starmie", Type1 = PokemonType.Water, Type2 = PokemonType.Psychic, Level = 50, Owner = misty, OwnerId = misty.Id };
        var psyduck = new Pokemon { Name = "Psyduck", Type1 = PokemonType.Water, Level = 35, Owner = misty, OwnerId = misty.Id };
        
        // Kanto - Brock's team
        var onix = new Pokemon { Name = "Onix", Type1 = PokemonType.Rock, Type2 = PokemonType.Ground, Level = 48, Owner = brock, OwnerId = brock.Id };
        var crobat = new Pokemon { Name = "Crobat", Type1 = PokemonType.Poison, Type2 = PokemonType.Flying, Level = 52, Owner = brock, OwnerId = brock.Id };
        
        // Johto - Ethan's team
        var typhlosion = new Pokemon { Name = "Typhlosion", Type1 = PokemonType.Fire, Level = 58, Owner = ethan, OwnerId = ethan.Id };
        var ampharos = new Pokemon { Name = "Ampharos", Type1 = PokemonType.Electric, Level = 55, Owner = ethan, OwnerId = ethan.Id };
        
        // Johto - Lyra's team
        var meganium = new Pokemon { Name = "Meganium", Type1 = PokemonType.Grass, Level = 56, Owner = lyra, OwnerId = lyra.Id };
        
        // Johto - Silver's team
        var feraligatr = new Pokemon { Name = "Feraligatr", Type1 = PokemonType.Water, Level = 60, Owner = silver, OwnerId = silver.Id };
        var sneasel = new Pokemon { Name = "Sneasel", Type1 = PokemonType.Dark, Type2 = PokemonType.Ice, Level = 54, Owner = silver, OwnerId = silver.Id };
        
        // Hoenn - Brendan's team
        var sceptile = new Pokemon { Name = "Sceptile", Type1 = PokemonType.Grass, Level = 59, Owner = brendan, OwnerId = brendan.Id };
        
        // Hoenn - May's team
        var blaziken = new Pokemon { Name = "Blaziken", Type1 = PokemonType.Fire, Type2 = PokemonType.Fighting, Level = 60, Owner = may, OwnerId = may.Id };
        
        // Hoenn - Steven's team (Champion)
        var metagross = new Pokemon { Name = "Metagross", Type1 = PokemonType.Steel, Type2 = PokemonType.Psychic, Level = 77, Owner = steven, OwnerId = steven.Id };
        var aggron = new Pokemon { Name = "Aggron", Type1 = PokemonType.Steel, Type2 = PokemonType.Rock, Level = 75, Owner = steven, OwnerId = steven.Id };
        
        // Sinnoh - Lucas's team
        var infernape = new Pokemon { Name = "Infernape", Type1 = PokemonType.Fire, Type2 = PokemonType.Fighting, Level = 62, Owner = lucas, OwnerId = lucas.Id };
        
        // Sinnoh - Dawn's team
        var piplup = new Pokemon { Name = "Piplup", Type1 = PokemonType.Water, Level = 45, Owner = dawn, OwnerId = dawn.Id };
        
        // Sinnoh - Cynthia's team (Champion)
        var garchomp = new Pokemon { Name = "Garchomp", Type1 = PokemonType.Dragon, Type2 = PokemonType.Ground, Level = 78, Owner = cynthia, OwnerId = cynthia.Id };
        var spiritomb = new Pokemon { Name = "Spiritomb", Type1 = PokemonType.Ghost, Type2 = PokemonType.Dark, Level = 76, Owner = cynthia, OwnerId = cynthia.Id };
        
        // Hisui - Rei's team
        var decidueye = new Pokemon { Name = "Decidueye", Type1 = PokemonType.Grass, Type2 = PokemonType.Fighting, Level = 65, Owner = rei, OwnerId = rei.Id };
        
        // Hisui - Akari's team
        var samurott = new Pokemon { Name = "Samurott", Type1 = PokemonType.Water, Type2 = PokemonType.Dark, Level = 64, Owner = akari, OwnerId = akari.Id };
        
        // Unova - Hilbert's team
        var serperior = new Pokemon { Name = "Serperior", Type1 = PokemonType.Grass, Level = 63, Owner = hilbert, OwnerId = hilbert.Id };
        
        // Unova - Hilda's team
        var emboar = new Pokemon { Name = "Emboar", Type1 = PokemonType.Fire, Type2 = PokemonType.Fighting, Level = 64, Owner = hilda, OwnerId = hilda.Id };
        
        // Unova - Nate's team
        var samurott2 = new Pokemon { Name = "Samurott", Type1 = PokemonType.Water, Level = 62, Owner = nate, OwnerId = nate.Id };
        
        // Kalos - Calem's team
        var greninja = new Pokemon { Name = "Greninja", Type1 = PokemonType.Water, Type2 = PokemonType.Dark, Level = 66, Owner = calem, OwnerId = calem.Id };
        
        // Kalos - Serena's team
        var delphox = new Pokemon { Name = "Delphox", Type1 = PokemonType.Fire, Type2 = PokemonType.Psychic, Level = 65, Owner = serena, OwnerId = serena.Id };
        
        // Kalos - Diantha's team (Champion)
        var gardevoir = new Pokemon { Name = "Gardevoir", Type1 = PokemonType.Psychic, Type2 = PokemonType.Fairy, Level = 80, Owner = diantha, OwnerId = diantha.Id };
        
        // Alola - Elio's team
        var incineroar = new Pokemon { Name = "Incineroar", Type1 = PokemonType.Fire, Type2 = PokemonType.Dark, Level = 67, Owner = elio, OwnerId = elio.Id };
        
        // Alola - Selene's team
        var primarina = new Pokemon { Name = "Primarina", Type1 = PokemonType.Water, Type2 = PokemonType.Fairy, Level = 66, Owner = selene, OwnerId = selene.Id };
        
        // Alola - Hau's team
        var raichu = new Pokemon { Name = "Raichu", Type1 = PokemonType.Electric, Type2 = PokemonType.Psychic, Level = 63, Owner = hau, OwnerId = hau.Id };
        
        // Galar - Victor's team
        var cinderace = new Pokemon { Name = "Cinderace", Type1 = PokemonType.Fire, Level = 68, Owner = victor, OwnerId = victor.Id };
        
        // Galar - Gloria's team
        var inteleon = new Pokemon { Name = "Inteleon", Type1 = PokemonType.Water, Level = 67, Owner = gloria, OwnerId = gloria.Id };
        
        // Galar - Leon's team (Champion)
        var charizardGalar = new Pokemon { Name = "Charizard", Type1 = PokemonType.Fire, Type2 = PokemonType.Flying, Level = 82, Owner = leon, OwnerId = leon.Id };
        var dragapult = new Pokemon { Name = "Dragapult", Type1 = PokemonType.Dragon, Type2 = PokemonType.Ghost, Level = 80, Owner = leon, OwnerId = leon.Id };
        
        // Paldea - Florian's team
        var skeledirge = new Pokemon { Name = "Skeledirge", Type1 = PokemonType.Fire, Type2 = PokemonType.Ghost, Level = 69, Owner = florian, OwnerId = florian.Id };
        
        // Paldea - Juliana's team
        var meowscarada = new Pokemon { Name = "Meowscarada", Type1 = PokemonType.Grass, Type2 = PokemonType.Dark, Level = 68, Owner = juliana, OwnerId = juliana.Id };
        
        // Paldea - Nemona's team
        var pawmot = new Pokemon { Name = "Pawmot", Type1 = PokemonType.Electric, Type2 = PokemonType.Fighting, Level = 70, Owner = nemona, OwnerId = nemona.Id };
        
        // Orre - Wes's team
        var espeon = new Pokemon { Name = "Espeon", Type1 = PokemonType.Psychic, Level = 55, Owner = wes, OwnerId = wes.Id };
        var umbreon = new Pokemon { Name = "Umbreon", Type1 = PokemonType.Dark, Level = 56, Owner = wes, OwnerId = wes.Id };
        
        // Orre - Michael's team
        var eevee = new Pokemon { Name = "Eevee", Type1 = PokemonType.Normal, Level = 40, Owner = michael, OwnerId = michael.Id };
        
        // Fiore - Solana's team
        var plusle = new Pokemon { Name = "Plusle", Type1 = PokemonType.Electric, Level = 38, Owner = solana, OwnerId = solana.Id };
        
        // Fiore - Lunick's team
        var minun = new Pokemon { Name = "Minun", Type1 = PokemonType.Electric, Level = 37, Owner = lunick, OwnerId = lunick.Id };
        
        // Almia - Kate's team
        var pachirisu = new Pokemon { Name = "Pachirisu", Type1 = PokemonType.Electric, Level = 42, Owner = kate, OwnerId = kate.Id };
        
        // Almia - Keith's team
        var munchlax = new Pokemon { Name = "Munchlax", Type1 = PokemonType.Normal, Level = 40, Owner = keith, OwnerId = keith.Id };
        
        // Oblivia - Summer's team
        var staraptor = new Pokemon { Name = "Staraptor", Type1 = PokemonType.Normal, Type2 = PokemonType.Flying, Level = 50, Owner = summer, OwnerId = summer.Id };
        
        // Oblivia - Ben's team
        var luxray = new Pokemon { Name = "Luxray", Type1 = PokemonType.Electric, Level = 49, Owner = ben, OwnerId = ben.Id };
        
        // Ransei - Nobunaga's team
        var zekrom = new Pokemon { Name = "Zekrom", Type1 = PokemonType.Dragon, Type2 = PokemonType.Electric, Level = 85, Owner = nobunaga, OwnerId = nobunaga.Id };
        
        // Ransei - Oichi's team
        var jigglypuff = new Pokemon { Name = "Jigglypuff", Type1 = PokemonType.Normal, Type2 = PokemonType.Fairy, Level = 45, Owner = oichi, OwnerId = oichi.Id };
        
        // Orange Islands - Drake's team
        var dragonite = new Pokemon { Name = "Dragonite", Type1 = PokemonType.Dragon, Type2 = PokemonType.Flying, Level = 73, Owner = drake, OwnerId = drake.Id };
        
        // Orange Islands - Luana's team
        var marowak = new Pokemon { Name = "Marowak", Type1 = PokemonType.Ground, Level = 60, Owner = luana, OwnerId = luana.Id };
        
        context.Pokemons.AddRange(
            pikachu, charizard, starmie, psyduck, onix, crobat,
            typhlosion, ampharos, meganium, feraligatr, sneasel,
            sceptile, blaziken, metagross, aggron,
            infernape, piplup, garchomp, spiritomb,
            decidueye, samurott,
            serperior, emboar, samurott2,
            greninja, delphox, gardevoir,
            incineroar, primarina, raichu,
            cinderace, inteleon, charizardGalar, dragapult,
            skeledirge, meowscarada, pawmot,
            espeon, umbreon, eevee,
            plusle, minun, pachirisu, munchlax,
            staraptor, luxray,
            zekrom, jigglypuff,
            dragonite, marowak
        );
        context.SaveChanges();
    }
}