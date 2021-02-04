using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.Company.DepartmentMembers.Commands.AddDepartmentMember
{
    public class AddDepartmentMemberCommandHandler : AsyncRequestHandler<AddDepartmentMemberCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMediator mediator;
        private readonly IRecipientLinkService recipientLinkService;

        public AddDepartmentMemberCommandHandler(IApplicationDbContext dbContext, IMediator mediator, IRecipientLinkService recipientLinkService)
        {
            this.dbContext = dbContext;
            this.mediator = mediator;
            this.recipientLinkService = recipientLinkService;
        }

        protected override async Task Handle(AddDepartmentMemberCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                await recipientLinkService.CreateRecipientLink<DepartmentRecipientLinks>(request.DepartmentId, request.EmployeeId);

                await mediator.Publish(new ReevaluatePermissions());

            }, cancellationToken);
        }
    }
}
