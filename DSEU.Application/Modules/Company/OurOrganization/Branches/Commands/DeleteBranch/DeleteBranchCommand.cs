using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Branches.Commands.DeleteBranch
{
    public record DeleteBranchCommand(int id) : IRequest;
}
