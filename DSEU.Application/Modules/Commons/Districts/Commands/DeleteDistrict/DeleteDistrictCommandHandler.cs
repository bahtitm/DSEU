using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstateRights.Cases;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.Districts.Commands.DeleteDistrict
{
    public class DeleteDistrictCommandHandler : AsyncRequestHandler<DeleteDistrictCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteDistrictCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteDistrictCommand request, CancellationToken cancellationToken)
        {
            var district = await dbContext.FindByIdAsync<District>(request.Id);
            dbContext.Set<District>().Remove(district);
            await dbContext.SaveChangesAsync();
        }
    }
}
