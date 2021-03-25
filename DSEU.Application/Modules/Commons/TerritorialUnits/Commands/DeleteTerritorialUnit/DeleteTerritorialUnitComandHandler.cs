using AutoMapper;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.TerritorialUnits.Commands.DeleteTerritorialUnit
{
    public class DeleteTerritorialUnitComandHandler : AsyncRequestHandler<DeleteTerritorialUnitComand>
    {
        private readonly IApplicationDbContext dbContext;
        public DeleteTerritorialUnitComandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
        }
        protected override async Task Handle(DeleteTerritorialUnitComand request, CancellationToken cancellationToken)
        {
            var terrUnit = await dbContext.FindByIdAsync<TerritorialUnit>(request.Id, cancellationToken);
            dbContext.Set<TerritorialUnit>().Remove(terrUnit);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
