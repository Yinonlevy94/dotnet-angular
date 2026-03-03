namespace PokemonApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int? OriginId { get; set; }
        public County? Origin { get; set; }
        
        public ICollection<Pokemon> MonsList { get; set; }

        public Owner()
        {
            MonsList = new List<Pokemon>();
        }
    }
}