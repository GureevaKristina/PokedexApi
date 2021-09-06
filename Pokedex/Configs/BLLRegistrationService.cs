using Microsoft.Extensions.DependencyInjection;
using Pokedex.Services.Implementation;
using Pokedex.Services.Interfaces;
using Pokedex.Services.PokeApi;
using Pokedex.Services.TranslatedApi;

namespace Pokedex.Configs
{
    public static class BLLRegistrationService
    {
        public static void AddBLLRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IPokedexService, PokedexService>();
            services.AddSingleton<IPokeApiService, PokeApiService>();
            services.AddSingleton<ITranslatedService, TranslatedService>();
        }
    }
}

