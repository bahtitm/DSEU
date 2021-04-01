using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.CreateRole
{
    public class CreateRoleComandHandler : AsyncRequestHandler<CreateRoleCommand>
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public CreateRoleComandHandler(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        protected override async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var roleResult = await roleManager.CreateAsync(new IdentityRole(request.Name));

            if (!roleResult.Succeeded)
            {
                throw new Exception();
            }

            var role = await roleManager.FindByNameAsync(request.Name);

            foreach (var claim in request.UserClaimTypes)
            {
                var roleClaim = new Claim(claim.ToString(), bool.TrueString);
                await roleManager.AddClaimAsync(role, roleClaim);
            }
        }
    }
}
