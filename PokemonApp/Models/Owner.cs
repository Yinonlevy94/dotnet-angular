namespace PokemonApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public County Origin { get; set; }
        public ICollection<Pokemon> MonsList { get; set; }

        public Owner()
        {
            this.MonsList = new List<Pokemon>(6);
        }

        public Owner(string name, County origin)
        {
            this.Name = name;
            this.Origin = origin;
        }
    }
    
    
}
