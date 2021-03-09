using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.RealEstates.Buildings.Commands.DeleteBuilding
{
    public class DeleteBuildingCommandHandler : AsyncRequestHandler<DeleteBuildingCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteBuildingCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await dbContext.Set<Building>().FirstOrDefaultAsync(p => p.Id == request.Id);
            dbContext.Set<Building>().Remove(building);
            await dbContext.SaveChangesAsync();
        }
    }
}
