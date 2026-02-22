namespace PokemonApp.Models
{
    public class County
    {
        public int id { get; set; }
        public string name { get; set; }

        public County(string name)
        {
            this.name = name;
        }
    }
}
