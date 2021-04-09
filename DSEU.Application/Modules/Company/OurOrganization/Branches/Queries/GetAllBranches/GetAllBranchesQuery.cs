using DSEU.Application.Modules.Company.OurOrganization.Branches.Dtos;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.Company.OurOrganization.Branches.Queries.GetAllBranches
{
    public class GetAllBranchesQuery : IRequest<IEnumerable<BranchDto>>
    {
    }
}
