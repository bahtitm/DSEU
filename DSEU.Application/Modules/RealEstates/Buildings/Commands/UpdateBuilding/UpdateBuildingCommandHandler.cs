using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.RealEstates.Buildings.Commands.UpdateBuilding
{
    public class UpdateBuildingCommandHandler : AsyncRequestHandler<UpdateBuildingCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateBuildingCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = await dbContext.Set<Building>().FirstOrDefaultAsync(p => p.Id == request.Id);
            mapper.Map(request, building);
            await dbContext.SaveChangesAsync();
        }
    }
}
