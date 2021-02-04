using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Events;

namespace DSEU.Application.Modules.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : AsyncRequestHandler<UpdateRoleCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public UpdateRoleCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IMediator mediator)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        protected override async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await dbContext.Set<Role>().FirstOrDefaultAsync(p => p.Id == request.Id);
            bool statusChanged = role.Status != request.Status;
            mapper.Map(request, role);
            await dbContext.SaveChangesAsync();

            if (statusChanged)
                await mediator.Publish(new ReevaluatePermissions());
        }
    }
}
