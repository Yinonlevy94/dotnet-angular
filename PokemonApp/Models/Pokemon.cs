namespace PokemonApp.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Enum? Type1 { get; set; }
        public Enum? Type2 { get; set; }
        public int Level { get; set; }

        public Owner Owner { get; set; }
        public Owner OT { get; set; }

        private ICollection<Attack> _attacks;

        private Item heldItem;

        public Pokemon(string Name, Enum Type1, Enum Type2, int level)
        {
            if (level > 100 || level < 1)
            {
                throw new ArgumentException("Level must be between 1 and 100.");
                Environment.Exit(1);
            }
            this._attacks = new List<Attack>(4);
            this.Type1 = Type1;
            this.Type2 = Type2;
            this.Name = Name;

        }
    }
}
