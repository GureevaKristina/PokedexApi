using System.Collections.Generic;

namespace Pokedex.Services.Models
{
    public class PokemonSpecies
    {
        public List<FlavorTextEntry> flavor_text_entries { get; set; }
        public Habitat habitat { get; set; }
        public int id { get; set; }
        public bool is_legendary { get; set; }
        public string name { get; set; }
    }
}
