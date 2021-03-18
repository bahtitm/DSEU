using AutoMapper;
using DSEU.Application.Modules.Commons.TerritorialUnits.Comands.CreateTerritorialUnit;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.TerritorialUnits
{
    public class TerritorialMappingProfile : Profile
    {
        public TerritorialMappingProfile()
        {
            CreateMap<CreateTerritorialUnitComand, TerritorialUnit>();
        }
    }
}