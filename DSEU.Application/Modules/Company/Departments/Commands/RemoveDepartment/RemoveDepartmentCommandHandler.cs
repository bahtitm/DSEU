using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.Company.Departments.Commands.RemoveDepartment
{
    public class RemoveDepartmentCommandHandler : AsyncRequestHandler<RemoveDepartmentCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IRoleMemberService roleMemberService;
        private readonly IRecipientLinkService recipientLinkService;
        private readonly IMediator mediator;

        public RemoveDepartmentCommandHandler(IApplicationDbContext dbContext,
            IRoleMemberService roleMemberService,
            IRecipientLinkService recipientLinkService,
            IMediator mediator)
        {
            this.dbContext = dbContext;
            this.roleMemberService = roleMemberService;
            this.recipientLinkService = recipientLinkService;
            this.mediator = mediator;
        }

        protected override async Task Handle(RemoveDepartmentCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                var department = await dbContext.FindByIdAsync<Department>(request.Id, cancellationToken);
                dbContext.Set<Department>().Remove(department);
                await dbContext.SaveChangesAsync(cancellationToken);

                if (department.ManagerId.HasValue)
                    await roleMemberService.RemoveFromRoleIfExists(department.ManagerId.Value, SystemRoles.DepartmentManager);

                await mediator.Publish(new ReevaluatePermissions());

            }, cancellationToken);

        }
    }
}
