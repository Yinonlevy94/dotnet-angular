namespace PokemonApp.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PokemonType? Type1 { get; set; }
        public PokemonType? Type2 { get; set; }
        public int Level { get; set; }

        // Relationships
        public int? OwnerId { get; set; }
        public Owner? Owner { get; set; }
        
        public ICollection<Attack> Attacks { get; set; }
        public Item? HeldItem { get; set; }

        public Pokemon()
        {
            Attacks = new List<Attack>(4);
        }
        
        public Pokemon(string name, PokemonType type1, PokemonType? type2, int level)
        {
            if (level > 100 || level < 1)
                throw new ArgumentException("Level must be between 1 and 100.");
            
            Attacks = new List<Attack>(4);
            Type1 = type1;
            Type2 = type2;
            Name = name;
            Level = level;
        }
    }
}