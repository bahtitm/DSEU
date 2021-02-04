using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Currencies.Commands.RemoveCurrency
{
    public class RemoveCurrencyCommandHandler : AsyncRequestHandler<RemoveCurrencyCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public RemoveCurrencyCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(RemoveCurrencyCommand request, CancellationToken cancellationToken)
        {
              
            var currency = await dbContext.FindByIdAsync<Currency>(request.Id, cancellationToken); 
            dbContext.Set<Currency>().Remove(currency);
            await dbContext.SaveChangesAsync();
        }

    }
}
