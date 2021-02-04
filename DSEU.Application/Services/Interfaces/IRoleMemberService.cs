using System.Threading.Tasks;

namespace DSEU.Application.Services.Interfaces
{
    public interface IRoleMemberService
    {
        Task GrantRole(int memberId, string role);
        Task GrantRoleIfNotExists(int memberId, string role);
        Task RemoveFromRole(int memberId, string role);
        Task RemoveFromRoleIfExists(int memberId, string role);
        Task RemoveFromRole(int memberId, int roleId);
        Task<bool> IsInRole(int memberId, string role);
    }
}
