using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Dtos.Commons
{
    public class LocalityDto : DatabookEntryDto, IMapFrom<Locality>
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
    }
}
