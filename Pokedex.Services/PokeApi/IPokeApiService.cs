using Pokedex.Services.BaseResults;

namespace Pokedex.Services.PokeApi
{
    public interface IPokeApiService
    {
        PokemonApiResult GetPokemonByName(string pokemonName);

    }
}
