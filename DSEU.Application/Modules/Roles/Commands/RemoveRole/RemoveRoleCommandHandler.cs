using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.Roles.Commands.RemoveRole
{
    public class RemoveRoleCommandHandler : AsyncRequestHandler<RemoveRoleCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMediator mediator;

        public RemoveRoleCommandHandler(IApplicationDbContext dbContext, IMediator mediator)
        {
            this.dbContext = dbContext;
            this.mediator = mediator;
        }

        protected override async Task Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {

            var role = await dbContext.FindByIdAsync<Role>(request.Id, cancellationToken);
            dbContext.Set<Role>().Remove(role);
            await dbContext.SaveChangesAsync();
            await mediator.Publish(new ReevaluatePermissions());
        }
    }
}
