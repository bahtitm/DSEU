using System.Collections.Generic;
using MediatR;
using DSEU.Application.Dtos.Company;

namespace DSEU.Application.Modules.Company.JobTitles.Queries.GetAllJobTitles
{
    public class GetAllJobTitlesQuery : IRequest<IEnumerable<JobTitleDto>>
    {
    }
}
