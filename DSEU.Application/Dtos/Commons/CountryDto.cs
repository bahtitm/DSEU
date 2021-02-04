using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Dtos.Commons
{
    public class CountryDto : DatabookEntryDto, IMapFrom<Country>
    {
        public string Name { get; set; }

    }
}
