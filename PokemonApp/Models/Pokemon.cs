using PokemonApp.Data;

namespace PokemonApp.Models
{
    
    public class Pokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public PokemonType? type1 { get; set; }
        public PokemonType? type2 { get; set; }
        public int level { get; set; }

        public string owner { get; set; }

        public ICollection<Attack> attacks;

        public Item? heldItem;

        public Pokemon()
        {
            this.attacks = new List<Attack>(4);
        }
        //actual ctor
        public Pokemon(string name, PokemonType type1, PokemonType type2, int level, string owner)
        {
            if (level > 100 || level < 1)
            {
                throw new ArgumentException("Level must be between 1 and 100.");
                Environment.Exit(1);
            }
            this.attacks = new List<Attack>(4);
            this.type1 = type1;
            this.type2 = type2;
            this.name = name;
            this.level = level;
            // this.heldItem = item;
            this.owner = owner;
        }
        
        
    }
}
