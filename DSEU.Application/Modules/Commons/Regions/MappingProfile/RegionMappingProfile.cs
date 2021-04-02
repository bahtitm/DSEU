using AutoMapper;
using DSEU.Application.Modules.Commons.Regions.Commands.CreateRegion;
using DSEU.Application.Modules.Commons.Regions.Commands.UpdateRegion;
using DSEU.Application.Modules.Commons.Regions.Dtos;
using DSEU.Domain.Entities.RealEstateRights.Cases;

namespace DSEU.Application.Modules.Commons.Regions.MappingProfile
{
    public class RegionMappingProfile : Profile
    {
        public RegionMappingProfile()
        {
            CreateMap<CreateRegionCommand, Region>();
            CreateMap<UpdateRegionCommand, Region>();

            CreateMap<Region, RegionDto>();
        }
    }
}
