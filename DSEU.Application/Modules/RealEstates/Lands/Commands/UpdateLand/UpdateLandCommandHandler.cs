using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.RealEstates.Lands.Commands.UpdateLand
{
    public class UpdateLandCommandHandler : AsyncRequestHandler<UpdateLandCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateLandCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateLandCommand request, CancellationToken cancellationToken)
        {
            var land = await dbContext.Set<Land>().FirstOrDefaultAsync(p => p.Id == request.Id);

            mapper.Map(request, land);
            await dbContext.SaveChangesAsync();
        }
    }
}
