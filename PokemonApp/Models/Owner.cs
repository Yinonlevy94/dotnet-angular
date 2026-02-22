namespace PokemonApp.Models
{
    public class Owner
    {
        public int id { get; set; }
        public string? name { get; set; }
        public County? origin { get; set; }
        public ICollection<Pokemon>? monsList { get; set; }

        public Owner()
        {
            this.monsList = new List<Pokemon>(6);
        }

        public Owner(string name, County origin)
        {
            this.name = name;
            this.origin = origin;
        }
    }
    
    
}
