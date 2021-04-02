using AutoMapper;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstateRights.Cases;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.Regions.Commands.UpdateRegion
{
    public class UpdateRegionCommandHandler : AsyncRequestHandler<UpdateRegionCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateRegionCommandHandler(IApplicationDbContext dbContext, IMapper mapper = null)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
        {
            var region = await dbContext.FindByIdAsync<Region>(request.Id, cancellationToken);
            mapper.Map(request, region);
            await dbContext.SaveChangesAsync();
        }
    }
}
