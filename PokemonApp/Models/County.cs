namespace PokemonApp.Models
{
    public class County
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public County(string name)
        {
            this.Name = name;
        }
    }
}
