using MediatR;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : AsyncRequestHandler<UpdateRoleCommand>
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public UpdateRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        protected override async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await roleManager.FindByIdAsync(request.Id);

            if (request.Name != null)
            {
                await roleManager.SetRoleNameAsync(role, request.Name);
            }

            if (request.UserClaimTypes.Any())
            {
                var oldClaims = await roleManager.GetClaimsAsync(role);

                foreach (var claim in oldClaims)
                {
                    await roleManager.RemoveClaimAsync(role, claim);
                }

                foreach (var claim in request.UserClaimTypes)
                {
                    var roleClaim = new Claim(claim.ToString(), bool.TrueString);
                    await roleManager.AddClaimAsync(role, roleClaim);
                }
            }
        }
    }
}
