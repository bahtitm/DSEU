using AutoMapper;
using DSEU.Application.Modules.Commons.Districts.Commands.CreateDistrict;
using DSEU.Application.Modules.Commons.Districts.Commands.UpdateDistrict;
using DSEU.Application.Modules.Commons.Districts.Dtos;
using DSEU.Domain.Entities.RealEstateRights.Cases;

namespace DSEU.Application.Modules.Commons.Districts.MappingProfile
{
    public class DistrictMappingProfile : Profile
    {
        public DistrictMappingProfile()
        {
            CreateMap<CreateDistrictCommand, District>();
            CreateMap<UpdateDistrictCommand, District>();

            CreateMap<District, DistrictDto>();
        }
    }
}
