using DSEU.Domain.Entities.OurOrganization;
using System.Threading.Tasks;

namespace DSEU.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }

        Task<User> GetUser();
    }
}
