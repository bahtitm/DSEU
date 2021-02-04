using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Localities.Commands.RemoveLocality
{
    public class RemoveLocalityCommandHandler : AsyncRequestHandler<RemoveLocalityCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public RemoveLocalityCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(RemoveLocalityCommand request, CancellationToken cancellationToken)
        {
            var locality = await dbContext.FindByIdAsync<Locality>(request.Id, cancellationToken); 
            dbContext.Set<Locality>().Remove(locality);
            await dbContext.SaveChangesAsync(cancellationToken);

        }

    }
}
