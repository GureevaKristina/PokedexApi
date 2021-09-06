using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pokedex.Services.BaseResults;
using Pokedex.Services.Models;
using RestSharp;
using System.Text.Json;

namespace Pokedex.Services.TranslatedApi
{
    public class TranslatedService : ITranslatedService
    {
        private RestClient _restClient;
        private readonly ILogger<TranslatedService> _logger;
        private IConfiguration _configuration;
        private const string yodaTranslate = "yoda.json";
        private const string shakespeareTranslate = "shakespeare.json";

        public TranslatedService(ILogger<TranslatedService> logger,
                              IConfiguration configuration)
        {
            _configuration = configuration;
            _restClient = new RestClient(configuration["TranslationApiUrl"]);
            _logger = logger;
        }
        public TranslatedApiResult GetTranslatedDescriptionForPokemon(BriefPokemonDescribe pokemon)
        {
            _logger.LogInformation($"GetTranslatedPokemonByName called with parameters: {nameof(pokemon.Name)} : {pokemon.Name}");

            var request = new RestRequest(Method.GET);

            request.Resource = (pokemon.IsLegendary || string.Equals("cave", pokemon.Habitah)) ? yodaTranslate : shakespeareTranslate;
            request.AddParameter("text", pokemon.Description);
            var restClient = _restClient.Execute(request);

            if (restClient.StatusCode != System.Net.HttpStatusCode.OK)
                return new TranslatedApiResult(restClient.ErrorMessage);
            var result = JsonSerializer.Deserialize<TranslatedText>(restClient.Content);

            return new TranslatedApiResult(result);
        }
    }
}
