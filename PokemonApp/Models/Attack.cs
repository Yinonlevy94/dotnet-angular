namespace PokemonApp.Models
{
    public class Attack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PokemonType AttackType { get; set; }
        public int Damage { get; set; }
    }
}
