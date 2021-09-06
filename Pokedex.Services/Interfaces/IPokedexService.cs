using Pokedex.Services.BaseResults;

namespace Pokedex.Services.Interfaces
{
    public interface IPokedexService
    {
        public PokemonResult GetPokemon(string name);
        public PokemonResult GetTranslatedPokemon(string name);
    }
}
