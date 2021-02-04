using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Countries.Commands.RemoveCountry
{
    public class RemoveCountryCommandHandler : AsyncRequestHandler<RemoveCountryCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public RemoveCountryCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(RemoveCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await dbContext.FindByIdAsync<Country>(request.Id, cancellationToken);
            dbContext.Set<Country>().Remove(country);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
