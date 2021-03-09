using AutoMapper;
using DSEU.Application.Modules.RealEstates.Lands.Commands.CreateLand;
using DSEU.Application.Modules.RealEstates.Lands.Commands.UpdateLand;
using DSEU.Application.Modules.RealEstates.Lands.Dtos;
using DSEU.Domain.Entities.RealEstates;

namespace DSEU.Application.Modules.RealEstates.Lands.MappingProfile
{
    public class LandMappingProfile : Profile
    {
        public LandMappingProfile()
        {
            CreateMap<CreateLandCommand, Land>();

            CreateMap<UpdateLandCommand, Land>();

            CreateMap<Land, LandDto>();
        }
    }
}
