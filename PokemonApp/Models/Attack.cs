namespace PokemonApp.Models
{
    public class Attack
    {
        public int id { get; set; }
        public string name { get; set; }
        public PokemonType attackType { get; set; }
        public int damage { get; set; }
    }
}
