using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;

namespace DSEU.Application.Modules.Parties.Organizations.Companies.Commands.RemoveCompany
{
    public class RemoveCompanyCommandHandler : AsyncRequestHandler<RemoveCompanyCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public RemoveCompanyCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(RemoveCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.Set<Domain.Entities.Parties.Company>().SingleAsync(prop => prop.Id == request.Id && !prop.IsCardReadOnly);
            dbContext.Set<Domain.Entities.Parties.Company>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
