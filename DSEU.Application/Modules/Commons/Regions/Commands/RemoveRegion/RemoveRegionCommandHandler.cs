using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Regions.Commands.RemoveRegion
{
    public class RemoveRegionCommandHandler : AsyncRequestHandler<RemoveRegionCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public RemoveRegionCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(RemoveRegionCommand request, CancellationToken cancellationToken)
        {
            var region = await dbContext.FindByIdAsync<Region>(request.Id, cancellationToken);
            dbContext.Set<Region>().Remove(region);
            await dbContext.SaveChangesAsync(cancellationToken);

        }

    }
}
