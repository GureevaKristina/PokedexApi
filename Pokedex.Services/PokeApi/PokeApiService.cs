using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pokedex.Services.BaseResults;
using Pokedex.Services.Models;
using RestSharp;
using System.Text.Json;

namespace Pokedex.Services.PokeApi
{
    public class PokeApiService : IPokeApiService
    {
        private RestClient _restClient;
        private readonly ILogger<PokeApiService> _logger;
        private IConfiguration _configuration;

        public PokeApiService(ILogger<PokeApiService> logger,
                              IConfiguration configuration)
        {
            _configuration = configuration;
            _restClient = new RestClient(configuration["PokeApiUrl"]);
            _logger = logger;
        }
        public PokemonApiResult GetPokemonByName(string pokemonName)
        {
            _logger.LogInformation($"GetPokemonByName called with parameters: {nameof(pokemonName)} : {pokemonName}");

            var request = new RestRequest(pokemonName, Method.GET);
            var restClient = _restClient.Execute(request);
           
            if (restClient.StatusCode != System.Net.HttpStatusCode.OK)
                return new PokemonApiResult(restClient.ErrorMessage);
            var result = JsonSerializer.Deserialize<PokemonSpecies>(restClient.Content);

            return new PokemonApiResult(result);
        }
    }
}
