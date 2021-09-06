using AutoMapper;
using Microsoft.Extensions.Logging;
using Pokedex.Services.BaseResults;
using Pokedex.Services.Interfaces;
using Pokedex.Services.PokeApi;
using Pokedex.Services.TranslatedApi;

namespace Pokedex.Services.Implementation
{
    public class PokedexService : IPokedexService
    {
        private readonly ILogger<PokedexService> _logger;
        private IPokeApiService _pokeApiService;
        private ITranslatedService _translatedService;
        private readonly IMapper _mapper;
        public PokedexService(ILogger<PokedexService> logger,
                              IPokeApiService pokeApiService,
                              ITranslatedService translatedService,
                              IMapper mapper)
        {
            _logger = logger;
            _translatedService = translatedService;
            _pokeApiService = pokeApiService;
            _mapper = mapper;
        }

        public PokemonResult GetPokemon(string name)
        {
            _logger.LogInformation($"GetPokemon called with parameters: {nameof(name)} : {name}");
            var resultApi = _pokeApiService.GetPokemonByName(name);
            var result = _mapper.Map<PokemonResult>(resultApi);
            return result;
        }

        public PokemonResult GetTranslatedPokemon(string name)
        {
            _logger.LogInformation($"GetTranslatedPokemon called with parameters: {nameof(name)} : {name}");
            var pokemon = GetPokemon(name);
            if (!pokemon.IsSuccess)
                return pokemon;

            var translatedResult = _translatedService.GetTranslatedDescriptionForPokemon(pokemon.Pokemon);
            if (translatedResult.IsSuccess)
                pokemon.Pokemon.Description = translatedResult.TranslatedText.contents.translated;

            return pokemon;
        }
    }
}
