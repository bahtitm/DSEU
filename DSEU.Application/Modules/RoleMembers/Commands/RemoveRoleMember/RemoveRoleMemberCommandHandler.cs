using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.RoleMembers.Commands.RemoveRoleMember
{
    public class RemoveRoleMemberCommandHandler : AsyncRequestHandler<RemoveRoleMemberCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IRoleMemberService roleMemberService;
        private readonly IMediator mediator;

        public RemoveRoleMemberCommandHandler(IApplicationDbContext dbContext, IRoleMemberService roleMemberService, IMediator mediator)
        {
            this.dbContext = dbContext;
            this.roleMemberService = roleMemberService;
            this.mediator = mediator;
        }

        protected override async Task Handle(RemoveRoleMemberCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                await roleMemberService.RemoveFromRole(request.MemberId, request.RoleId);

                await mediator.Publish(new ReevaluatePermissions());

            }, cancellationToken);
        }
    }
}
