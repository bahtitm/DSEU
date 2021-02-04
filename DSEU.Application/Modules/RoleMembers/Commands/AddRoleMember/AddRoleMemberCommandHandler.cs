using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.RoleMembers.Commands.AddRoleMember
{
    public class AddRoleMemberCommandHandler : AsyncRequestHandler<AddRoleMemberCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IRecipientLinkService recipientLinkService;
        private readonly IMediator mediator;

        public AddRoleMemberCommandHandler(IApplicationDbContext dbContext, IRecipientLinkService recipientLinkService, IMediator mediator)
        {
            this.dbContext = dbContext;
            this.recipientLinkService = recipientLinkService;
            this.mediator = mediator;
        }

        protected override async Task Handle(AddRoleMemberCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                await recipientLinkService.CreateRecipientLink<RoleRecipientLinks>(request.RoleId, request.MemberId);

                await mediator.Publish(new ReevaluatePermissions());

            }, cancellationToken);
        }
    }
}
