using DSEU.Application.Modules.Company.OurOrganization.Role.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Queries.GetRoleDetail
{
    public class GetRoleDetailQueryHandler : IRequestHandler<GetRoleDetailQuery, RoleDetailDto>
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public GetRoleDetailQueryHandler(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<RoleDetailDto> Handle(GetRoleDetailQuery request, CancellationToken cancellationToken)
        {
            var roleDto = new RoleDetailDto();

            var role = await roleManager.FindByIdAsync(request.Id);

            roleDto.Name = role.Name;

            var claims = await roleManager.GetClaimsAsync(role);

            foreach (var claim in claims)
            {
                roleDto.Claims.Add(claim.Type.ToString());
            }

            return roleDto;
        }
    }
}
