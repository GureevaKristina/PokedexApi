using Pokedex.Services.Models;

namespace Pokedex.Services.BaseResults
{
    public class PokemonApiResult : BaseResult
    {
        public PokemonSpecies Pokemon { get; set; }

        public PokemonApiResult(string error)
            : base(error)
        {

        }
        public PokemonApiResult(PokemonSpecies pokemon)
        {
            this.Pokemon = pokemon;
            IsSuccess = true;
        }
    }
}
