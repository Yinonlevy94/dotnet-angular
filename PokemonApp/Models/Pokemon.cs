using PokemonApp.Data;

namespace PokemonApp.Models
{
    
    public class Pokemon
    {
        public int Id { get; set; }
        public string name { get; set; }
        public PokemonType? type1 { get; set; }
        public PokemonType? type2 { get; set; }
        public int Level { get; set; }

        public Owner Owner { get; set; }

        public ICollection<Attack> _attacks;

        public Item heldItem;

        public Pokemon()
        {
            this._attacks = new List<Attack>(4);
        }
        //actual ctor
        public Pokemon(string name, PokemonType type1, PokemonType type2, int level, Item item)
        {
            if (level > 100 || level < 1)
            {
                throw new ArgumentException("Level must be between 1 and 100.");
                Environment.Exit(1);
            }
            this._attacks = new List<Attack>(4);
            this.type1 = type1;
            this.type2 = type2;
            this.name = name;
            this.Level = level;
            this.heldItem = item;
        }
        
        
    }
}
