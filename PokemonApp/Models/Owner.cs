namespace PokemonApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public County Origin { get; set; }

        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
