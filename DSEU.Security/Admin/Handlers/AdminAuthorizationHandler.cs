using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Security.Admin.Requirements;

namespace DSEU.Security.Admin.Handlers
{
    public class AdminAuthorizationHandler : AuthorizationHandler<AdminRequirement>
    {
        private readonly ICurrentUserService currentUserService;

        public AdminAuthorizationHandler(ICurrentUserService currentUserService)
        {
            this.currentUserService = currentUserService;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
        {
            if (await currentUserService.IsAdmin())
                context.Succeed(requirement);
        }
    }
}
