using PokemonApp.Data;

namespace PokemonApp.Models
{
    
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PokemonType? Type1 { get; set; }
        public PokemonType? Type2 { get; set; }
        public int Level { get; set; }

        public string Owner { get; set; }

        public ICollection<Attack> Attacks;

        public Item? HeldItem;

        public Pokemon()
        {
            this.Attacks = new List<Attack>(4);
        }
        //actual ctor
        public Pokemon(string name, PokemonType type1, PokemonType type2, int level, string owner)
        {
            if (level > 100 || level < 1)
            {
                throw new ArgumentException("Level must be between 1 and 100.");
                Environment.Exit(1);
            }
            this.Attacks = new List<Attack>(4);
            this.Type1 = type1;
            this.Type2 = type2;
            this.Name = name;
            this.Level = level;
            // this.heldItem = item;
            this.Owner = owner;
        }
        
        
    }
}
