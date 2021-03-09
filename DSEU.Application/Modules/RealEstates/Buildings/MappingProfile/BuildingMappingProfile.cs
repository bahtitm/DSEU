using AutoMapper;
using DSEU.Application.Modules.RealEstates.Buildings.Commands.CreateBuilding;
using DSEU.Application.Modules.RealEstates.Buildings.Commands.UpdateBuilding;
using DSEU.Application.Modules.RealEstates.Buildings.Dtos;
using DSEU.Domain.Entities.RealEstates;

namespace DSEU.Application.Modules.RealEstates.Buildings.MappingProfile
{
    public class BuildingMappingProfile : Profile
    {
        public BuildingMappingProfile()
        {
            CreateMap<CreateBuildingCommand, Building>();

            CreateMap<UpdateBuildingCommand, Building>();

            CreateMap<Building, BuildingDto>();
        }
    }
}
