using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstateRights.Cases;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.Regions.Commands.DeleteRegion
{
    public class DeleteRegionCommandHandler : AsyncRequestHandler<DeleteRegionCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteRegionCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
        {
            var region = await dbContext.FindByIdAsync<Region>(request.Id, cancellationToken);
            dbContext.Set<Region>().Remove(region);
            await dbContext.SaveChangesAsync();
        }
    }
}
