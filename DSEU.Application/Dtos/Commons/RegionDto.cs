using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Dtos.Commons
{
    public class RegionDto : DatabookEntryDto, IMapFrom<Region>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
