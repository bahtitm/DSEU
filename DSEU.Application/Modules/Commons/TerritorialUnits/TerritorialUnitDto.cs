using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.TerritorialUnits
{
    public class TerritorialUnitDto: IMapFrom<TerritorialUnit>
    {
        public string Name { get; set; }
    }
}
