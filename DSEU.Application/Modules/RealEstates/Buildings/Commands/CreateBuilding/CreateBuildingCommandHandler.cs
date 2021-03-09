using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstates;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.RealEstates.Buildings.Commands.CreateBuilding
{
    public class CreateBuildingCommandHandler : AsyncRequestHandler<CreateBuildingCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateBuildingCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var building = mapper.Map<Building>(request);
            await dbContext.AddAsync(building);
            await dbContext.SaveChangesAsync();
        }
    }
}
