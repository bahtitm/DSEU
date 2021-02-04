using MediatR;

namespace DSEU.Application.Modules.RoleMembers.Commands.RemoveRoleMember
{
    public class RemoveRoleMemberCommand : IRequest
    {
        public RemoveRoleMemberCommand(int roleId, int memberId)
        {
            RoleId = roleId;
            MemberId = memberId;
        }
        public int RoleId { get; }
        public int MemberId { get; }
    }
}
