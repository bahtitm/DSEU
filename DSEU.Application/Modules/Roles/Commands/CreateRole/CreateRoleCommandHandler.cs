using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Modules.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler : AsyncRequestHandler<CreateRoleCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateRoleCommandHandler(IMapper mapper, IApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        protected override async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            Role role = mapper.Map<Role>(request);
            await dbContext.AddAsync(role, cancellationToken);
            await dbContext.SaveChangesAsync();
        }
    }
}
