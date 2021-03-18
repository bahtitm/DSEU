using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.TerritorialUnits.Comands.CreateTerritorialUnit
{
    public class CreateTerritorialUnitComandHandler : AsyncRequestHandler<CreateTerritorialUnitComand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateTerritorialUnitComandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        protected override async Task Handle(CreateTerritorialUnitComand request, CancellationToken cancellationToken)
        {
            var terUnit = mapper.Map<TerritorialUnit>(request);
            await dbContext.AddAsync(terUnit);
            await dbContext.SaveChangesAsync();


        }
    }
}
