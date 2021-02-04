using AutoMapper;
using DSEU.Application.Modules.Commons.Localities.Commands.CreateLocality;
using DSEU.Application.Modules.Commons.Localities.Commands.EditLocality;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.MappingProfiles
{
    public class LocalityMappingProfile : Profile
    {
        public LocalityMappingProfile()
        {
            CreateMap<CreateLocalityCommand, Locality>();
            CreateMap<EditLocalityCommand, Locality>();
        }
    }
}
