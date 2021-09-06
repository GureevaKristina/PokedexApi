using AutoMapper;
using Pokedex.Services.BaseResults;
using Pokedex.Services.Models;
using System.Linq;

namespace Pokedex.Configs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PokemonApiResult, PokemonResult>();
            CreateMap<PokemonSpecies, BriefPokemonDescribe>()
                .ForMember(x => x.Description, opt => opt.MapFrom(c => c.flavor_text_entries.FirstOrDefault().flavor_text.Replace("\n", string.Empty)))
                .ForMember(x => x.Habitah, opt => opt.MapFrom(c => c.habitat.name))
                .ForMember(x => x.IsLegendary, opt => opt.MapFrom(c => c.is_legendary))
                .ForMember(x => x.Name, opt => opt.MapFrom(c => c.name));
        }
    }
}
