using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.RealEstates;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.RealEstates.Lands.Commands.CreateLand
{
    public class CreateLandCommandHandler : AsyncRequestHandler<CreateLandCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateLandCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateLandCommand request, CancellationToken cancellationToken)
        {
            var land = mapper.Map<Land>(request);
            await dbContext.AddAsync(land);
            await dbContext.SaveChangesAsync();
        }
    }
}
