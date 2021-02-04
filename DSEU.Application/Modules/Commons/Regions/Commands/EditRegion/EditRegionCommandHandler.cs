using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Regions.Commands.EditRegion
{
    public class EditRegionCommandHandler : AsyncRequestHandler<EditRegionCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public EditRegionCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(EditRegionCommand request, CancellationToken cancellationToken)
        {
            var region = await dbContext.FindByIdAsync<Region>(request.Id,cancellationToken);

            mapper.Map(request, region);
            await dbContext.SaveChangesAsync();
        }
    }
}
