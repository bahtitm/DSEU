using AutoMapper;
using DSEU.Application.Modules.Commons.TerritorialUnits.Commands.CreateTerritorialUnit;
using DSEU.Application.Modules.Commons.TerritorialUnits.Commands.UpdateTerritorialUnit;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.TerritorialUnits
{
    public class TerritorialMappingProfile : Profile
    {
        public TerritorialMappingProfile()
        {
            CreateMap<CreateTerritorialUnitComand, TerritorialUnit>();
            CreateMap<UpdateTerritorialUnitCommand, TerritorialUnit>();
            //CreateMap<DeleteTerritorialUnitComand, TerritorialUnit>();

            CreateMap<TerritorialUnit, TerritorialUnitDto>();
        }
    }
}