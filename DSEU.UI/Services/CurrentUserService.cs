using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.OurOrganization;
using DSEU.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DSEU.UI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IApplicationDbContext dbContext;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor,
            IApplicationDbContext dbContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }

        public int UserId => GetUserId();

        public async Task<User> GetUser()
        {
            var userId = UserId;
            return await dbContext.Set<User>().FindAsync(userId);
        }

        private int GetUserId()
        {
            return httpContextAccessor.HttpContext?.User?.UserId() ?? 0;
        }
    }
}
