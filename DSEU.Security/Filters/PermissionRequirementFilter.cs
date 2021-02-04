using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Policies;

namespace DSEU.Security.Filters
{
    public class PermissionRequirementFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationService authorizationService;
        private readonly EntityTypeGuid entityType;
        private readonly AccessRightsOperation operation;

        public PermissionRequirementFilter(EntityTypeGuid entityType, AccessRightsOperation operation, IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
            this.entityType = entityType;
            this.operation = operation;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var policyName = PermisionPolicyGenerator.GeneratePolicyName(entityType, operation);
            var result = await authorizationService.AuthorizeAsync(context.HttpContext.User, policyName);
            if (!result.Succeeded)
                context.Result = new ForbidResult();
        }
    }
}
