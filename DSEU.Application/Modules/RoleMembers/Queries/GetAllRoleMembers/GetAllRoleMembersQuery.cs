using System.Collections.Generic;
using MediatR;
using DSEU.Application.Dtos.CoreEntities;

namespace DSEU.Application.Modules.RoleMembers.Queries.GetAllRoleMembers
{
    public class GetAllRoleMembersQuery : IRequest<IEnumerable<RoleMemberDto>>
    {
        public int RoleId { get; }
        public GetAllRoleMembersQuery(int roleId)
        {
            RoleId = roleId;
        }
    }
}
