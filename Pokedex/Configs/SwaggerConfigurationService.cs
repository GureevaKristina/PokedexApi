using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace Pokedex.Configs
{
    public static class SwaggerConfigurationService
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            //Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Pokedex API",
                    Version = "v1"
                });
            });

        }
    }
}
