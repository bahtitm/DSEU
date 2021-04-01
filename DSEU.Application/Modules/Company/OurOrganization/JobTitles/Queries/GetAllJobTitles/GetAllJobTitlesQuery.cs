using DSEU.Application.Modules.Company.OurOrganization.JobTitles.Dtos;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.Company.OurOrganization.JobTitles.Queries.GetAllJobTitles
{
    public class GetAllJobTitlesQuery : IRequest<IEnumerable<JobTitleDto>>
    {

    }
}
