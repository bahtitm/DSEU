using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Banks.Commands.RemoveBank
{
    public class RemoveBankCommandHandler : AsyncRequestHandler<RemoveBankCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public RemoveBankCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(RemoveBankCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.FindByIdAsync<Bank>(request.Id, cancellationToken);
            dbContext.Set<Bank>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }


    }
}
