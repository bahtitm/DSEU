using AutoMapper;
using DSEU.Application.Modules.Commons.Countries.Commands.CreateCountry;
using DSEU.Application.Modules.Commons.Countries.Commands.EditCountry;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.MappingProfiles
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<CreateCountryCommand, Country>();
            CreateMap<EditCountryCommand, Country>();
        }
    }
}
