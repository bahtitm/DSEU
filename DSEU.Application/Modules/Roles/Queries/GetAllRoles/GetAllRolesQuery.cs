using System.Collections.Generic;
using MediatR;
using DSEU.Application.Dtos.CoreEntities;

namespace DSEU.Application.Modules.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<IEnumerable<RoleDto>>
    {

    }
}
