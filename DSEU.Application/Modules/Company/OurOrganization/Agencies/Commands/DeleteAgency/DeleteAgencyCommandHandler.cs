using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Agencies.Commands.DeleteAgency
{
    public class DeleteAgencyCommandHandler : AsyncRequestHandler<DeleteAgencyCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteAgencyCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteAgencyCommand request, CancellationToken cancellationToken)
        {
            var agency = await dbContext.FindByIdAsync<Agency>(request.id, cancellationToken);
            dbContext.Set<Agency>().Remove(agency);
            await dbContext.SaveChangesAsync();
        }
    }
}
