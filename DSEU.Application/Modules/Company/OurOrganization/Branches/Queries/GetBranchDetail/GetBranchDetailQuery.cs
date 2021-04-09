using DSEU.Application.Modules.Company.OurOrganization.Branches.Dtos;
using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Branches.Queries.GetBranchDetail
{
    public record GetBranchDetailQuery(int id) : IRequest<BranchDto>;
}
