using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.RealEstates.Lands.Commands.DeleteLand
{
    public class DeleteLandCommandHandler : AsyncRequestHandler<DeleteLandCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteLandCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteLandCommand request, CancellationToken cancellationToken)
        {
            var land = await dbContext.Set<Land>().FirstOrDefaultAsync(p => p.Id == request.Id);

            dbContext.Set<Land>().Remove(land);
            await dbContext.SaveChangesAsync();
        }
    }
}
