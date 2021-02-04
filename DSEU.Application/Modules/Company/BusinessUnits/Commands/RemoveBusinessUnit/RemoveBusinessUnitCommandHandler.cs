using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.Company.BusinessUnits.Commands.RemoveBusinessUnit
{
    public class RemoveBusinessUnitCommandHandler : AsyncRequestHandler<RemoveBusinessUnitCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IRoleMemberService roleMemberService;
        private readonly IMediator mediator;

        public RemoveBusinessUnitCommandHandler(IApplicationDbContext dbContext,
            IRoleMemberService roleMemberService, IMediator mediator)
        {
            this.dbContext = dbContext;
            this.roleMemberService = roleMemberService;
            this.mediator = mediator;
        }

        protected override async Task Handle(RemoveBusinessUnitCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                var businessUnit = await dbContext.Set<BusinessUnit>().Include(p => p.Company).SingleAsync(p => p.Id == request.Id, cancellationToken);
                dbContext.Set<BusinessUnit>().Remove(businessUnit);
                dbContext.Set<Domain.Entities.Parties.Company>().Remove(businessUnit.Company);
                await dbContext.SaveChangesAsync(cancellationToken);

                if (businessUnit.CEO.HasValue)
                {
                    await roleMemberService.RemoveFromRoleIfExists(businessUnit.CEO.Value, SystemRoles.BusinessUnitHead);
                }

                await mediator.Publish(new ReevaluatePermissions());

            }, cancellationToken);
        }
    }
}
