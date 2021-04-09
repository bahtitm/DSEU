using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Branches.Commands.DeleteBranch
{
    public class DeleteBranchCommandHandler : AsyncRequestHandler<DeleteBranchCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteBranchCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await dbContext.FindByIdAsync<Branch>(request.id);
            dbContext.Set<Branch>().Remove(branch);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
