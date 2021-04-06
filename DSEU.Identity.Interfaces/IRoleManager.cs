using DSEU.Application.Common.Enums;
using DSEU.Application.Modules.Company.OurOrganization.Role.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DSEU.Application.Common.Interfaces
{
    public interface IRoleManager
    {
        Task CreateRoleAsync(string role, IEnumerable<UserClaimTypes> claims);
        Task<IEnumerable<RoleDto>> GetAllRoles();
        Task<RoleDetailDto> GetRoleById(string id);
        Task UpdateClaimsAsync(string id, IEnumerable<UserClaimTypes> claims);
        Task UpdateRoleNameAsync(string id, string roleName);
        Task DeleteRoleAsync(string id);
    }
}
