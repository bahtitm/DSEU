using DSEU.Application.Common.Interfaces;
using DSEU.Shared.Extensions;
using Microsoft.AspNetCore.Http;

namespace DSEU.UI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public int UserId => GetUserId();


        private int GetUserId()
        {
            return httpContextAccessor.HttpContext?.User?.UserId() ?? 0;
        }

    }
}
