using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.CreateUser
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;
        private readonly IRoleManager roleManager;

        public CreateUserCommandHandler(IApplicationDbContext dbContext, IMapper mapper, IIdentityService identityService, IRoleManager roleManager)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.identityService = identityService;
            this.roleManager = roleManager;
        }

        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                var user = mapper.Map<User>(request);
                var identityUserId = await identityService.CreateUserAsync(user.Name, user.Email, cancellationToken: cancellationToken);
                user.UserId = identityUserId;

                await dbContext.AddAsync(user);
                await dbContext.SaveChangesAsync();

                var role = await roleManager.GetRoleById(request.RoleId);
                await identityService.AddToRoleAsync(identityUserId, role.Name);
            }, cancellationToken);
        }
    }
}
