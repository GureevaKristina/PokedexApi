using Pokedex.Services.BaseResults;
using Pokedex.Services.Models;

namespace Pokedex.Services.TranslatedApi
{
    public interface ITranslatedService
    {
        TranslatedApiResult GetTranslatedDescriptionForPokemon(BriefPokemonDescribe pokemon);
    }
}
