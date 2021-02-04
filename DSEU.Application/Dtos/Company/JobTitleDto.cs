using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Dtos.Company
{
    public class JobTitleDto : DatabookEntryDto, IMapFrom<JobTitle>
    {
        public string Name { get; set; }
    }
}
