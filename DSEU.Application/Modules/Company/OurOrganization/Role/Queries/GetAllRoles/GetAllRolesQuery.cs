using DSEU.Application.Modules.Company.OurOrganization.Role.Dtos;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Queries.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<IEnumerable<RoleDto>> { }
}
