using Pokedex.Services.Models;

namespace Pokedex.Services.BaseResults
{
    public class PokemonResult: BaseResult
    {
        public BriefPokemonDescribe Pokemon { get; set; }

        public PokemonResult(string error)
            :base(error)
        {

        }
        public PokemonResult(BriefPokemonDescribe pokemon)
        {
            this.Pokemon = pokemon;
            IsSuccess = true;
        }
    }
}
