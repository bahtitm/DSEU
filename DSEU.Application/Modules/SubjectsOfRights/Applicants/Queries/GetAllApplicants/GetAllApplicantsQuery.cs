using DSEU.Application.Modules.Statements.Commands;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.SubjectsOfRights.Applicants.Queries.GetAllApplicants
{
    public class GetAllApplicantsQuery : IRequest<IEnumerable<ApplicantDto>>
    {

    }
}
