using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons.TerritorialUnitOneToManyPrinciple;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.Regions.Commands.CreateRegion
{
    public class CreateRegionCommandHandler : AsyncRequestHandler<CreateRegionCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateRegionCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {
            var region = mapper.Map<Region>(request);

            await dbContext.AddAsync(region);
            await dbContext.SaveChangesAsync();
        }
    }
}
