using DSEU.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : AsyncRequestHandler<UpdateRoleCommand>
    {
        private readonly IRoleManager roleManager;

        public UpdateRoleCommandHandler(IRoleManager roleManager)
        {
            this.roleManager = roleManager;
        }

        protected override async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Name))
            {
                await roleManager.UpdateRoleNameAsync(request.Id, request.Name);
            }
            await roleManager.UpdateClaimsAsync(request.Id, request.UserClaimTypes);
        }
    }
}
