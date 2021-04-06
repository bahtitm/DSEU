using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Company.OurOrganization.Role.Dtos;
using DSEU.Application.Modules.Company.OurOrganization.Role.Queries.GetAllRoles;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleDto>>
    {
        private readonly IRoleManager roleManager;

        public GetAllRolesQueryHandler(IRoleManager roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<IEnumerable<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = roleManager.GetAllRoles();
            return await Task.FromResult(roles.Result);
        }
    }
}
