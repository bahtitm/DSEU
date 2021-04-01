using DSEU.Application.Common.Mapping;
using DSEU.Application.Dtos;
using DSEU.Domain.Entities.OurOrganization;

namespace DSEU.Application.Modules.Company.OurOrganization.JobTitles.Dtos
{
    public class JobTitleDto : DatabookEntryDto, IMapFrom<JobTitle>
    {

    }
}
