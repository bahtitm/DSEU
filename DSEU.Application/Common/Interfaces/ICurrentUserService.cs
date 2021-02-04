using System.Collections.Generic;
using System.Threading.Tasks;

namespace DSEU.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Task<bool> IsAdmin();
        Task<bool> IsAdminOrAuditor();
        Task<IEnumerable<int>> IncudeInGroups();
        Task SwitchToServiceUser();
        int UserId { get; }
    }
}
