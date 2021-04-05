using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper mapper;
        private readonly RoleManager<IdentityRole> roleManager;

        public GetAllRolesQueryHandler(IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            this.mapper = mapper;
            this.roleManager = roleManager;
        }

        public async Task<IEnumerable<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(roleManager.Roles.ProjectTo<RoleDto>(mapper.ConfigurationProvider));
        }
    }
}
