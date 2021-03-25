using AutoMapper;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.TerritorialUnits.Commands.UpdateTerritorialUnit
{
    public class UpdateTerritorialUnitCommandHandler : AsyncRequestHandler<UpdateTerritorialUnitCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateTerritorialUnitCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(UpdateTerritorialUnitCommand request, CancellationToken cancellationToken)
        {
            var terrUnit = await dbContext.FindByIdAsync<TerritorialUnit>(request.Id, cancellationToken);

            mapper.Map(request, terrUnit);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
