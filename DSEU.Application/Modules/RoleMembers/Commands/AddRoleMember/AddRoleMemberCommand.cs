using MediatR;

namespace DSEU.Application.Modules.RoleMembers.Commands.AddRoleMember
{
    public class AddRoleMemberCommand : IRequest
    {
        public int RoleId { get; set; }
        public int MemberId { get; set; }
    }
}
