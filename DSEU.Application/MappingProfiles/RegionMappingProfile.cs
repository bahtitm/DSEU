using AutoMapper;
using DSEU.Application.Modules.Commons.Regions.Commands.CreateRegion;
using DSEU.Application.Modules.Commons.Regions.Commands.EditRegion;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.MappingProfiles
{
    public class RegionMappingProfile : Profile
    {
        public RegionMappingProfile()
        {
            CreateMap<CreateRegionCommand, Region>();
            CreateMap<EditRegionCommand, Region>();
        }
    }
}
