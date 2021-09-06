using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.Services.Interfaces;
using Pokedex.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private IPokedexService _pokedexService;
        public PokemonController(ILogger<PokemonController> logger,
            IPokedexService pokedexService)
        {
            _logger = logger;
            _pokedexService = pokedexService;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(BriefPokemonDescribe), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult GetPokemon(string pokemonName)
        {
            _logger.LogInformation($"GetPokemon called with name: {pokemonName}");

            var result = _pokedexService.GetPokemon(pokemonName);

            if (!result.IsSuccess)
            {
                _logger.LogError(result.ErrorMessage);
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Pokemon);
        }

        [HttpGet]
        [Route("translated")]
        [ProducesResponseType(typeof(BriefPokemonDescribe), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult GetTranslatedPokemon(string pokemonName)
        {
            _logger.LogInformation($"GetTranslatedPokemon called with name: {pokemonName}");

            var result = _pokedexService.GetTranslatedPokemon(pokemonName);

            if (!result.IsSuccess)
            {
                _logger.LogError(result.ErrorMessage);
                return BadRequest(result.ErrorMessage); 
            }

            return Ok(result.Pokemon);
        }
    }
}
