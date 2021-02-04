using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.Company.DepartmentMembers.Commands.RemoveDepartmentMember
{
    public class RemoveDepartmentMemberCommandHandler : AsyncRequestHandler<RemoveDepartmentMemberCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMediator mediator;
        private readonly IRecipientLinkService recipientLinkService;

        public RemoveDepartmentMemberCommandHandler(IApplicationDbContext dbContext, IMediator mediator, IRecipientLinkService recipientLinkService)
        {
            this.dbContext = dbContext;
            this.mediator = mediator;
            this.recipientLinkService = recipientLinkService;
        }

        protected override async Task Handle(RemoveDepartmentMemberCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                await recipientLinkService.RemoveRecipientLink<DepartmentRecipientLinks>(request.DepartmentId, request.EmployeeId);
                await mediator.Publish(new ReevaluatePermissions());

            }, cancellationToken);

        }
    }
}
