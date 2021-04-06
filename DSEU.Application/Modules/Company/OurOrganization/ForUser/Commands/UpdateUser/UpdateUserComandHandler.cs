using AutoMapper;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Domain.Entities.OurOrganization;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.UpdateUser
{
    public class UpdateUserComandHandler : AsyncRequestHandler<UpdateUserComand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IIdentityService identityService;
        private readonly IRoleManager roleManager;
        public UpdateUserComandHandler(IApplicationDbContext dbContext, IMapper mapper, IIdentityService identityService, IRoleManager roleManager)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.identityService = identityService;
            this.roleManager = roleManager;
        }
        protected override async Task Handle(UpdateUserComand request, CancellationToken cancellationToken)
        {
            await dbContext.InvokeTransactionAsync(async () =>
            {
                var user = await dbContext.FindByIdAsync<User>(request.Id, cancellationToken);
                mapper.Map(request, user);

                await dbContext.SaveChangesAsync(cancellationToken);

                if (!string.IsNullOrEmpty(request.RoleId))
                {
                    await identityService.RemoveFromRoleAsync(user.UserId);

                    var role = await roleManager.GetRoleById(request.RoleId);
                    await identityService.AddToRoleAsync(user.UserId, role.Name);
                }
            }, cancellationToken);
        }
    }
}
