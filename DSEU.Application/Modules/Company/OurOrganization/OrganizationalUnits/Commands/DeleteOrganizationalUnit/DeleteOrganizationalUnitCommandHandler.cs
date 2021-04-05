using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Commands.DeleteOrganizationalUnit
{
    public class DeleteOrganizationalUnitCommandHandler : AsyncRequestHandler<DeleteOrganizationalUnitCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteOrganizationalUnitCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteOrganizationalUnitCommand request, CancellationToken cancellationToken)
        {
            var organizationalUnit = await dbContext.FindByIdAsync<OrganizationalUnit>(request.Id, cancellationToken);
            dbContext.Set<OrganizationalUnit>().Remove(organizationalUnit);
            await dbContext.SaveChangesAsync();
        }
    }
}
