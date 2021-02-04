using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.CoreEntities;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.AccessRights.Requirements;

namespace DSEU.Security.AccessRights.Handlers
{
    public class GrantAccessRightsAuthorizationHandler : AuthorizationHandler<GrantAccessRightsRequirement, GrantAccessRightsPermissionRequest>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly ICurrentUserService currentUserService;
        private readonly IAccessRightsService accessRightsService;

        public GrantAccessRightsAuthorizationHandler(IReadOnlyApplicationDbContext dbContext,
            ICurrentUserService currentUserService, IAccessRightsService accessRightsService)
        {
            this.dbContext = dbContext;
            this.currentUserService = currentUserService;
            this.accessRightsService = accessRightsService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, GrantAccessRightsRequirement requirement, GrantAccessRightsPermissionRequest resource)
        {
            if (await currentUserService.IsAdmin())
            {
                context.Succeed(requirement);
                return;
            }

            var accessRightEntity = new AccessRightEntity(resource.EntityId, resource.EntityType);
            var assigneeOperation = await accessRightsService.GetAccessRightInstancePriorityOperation(context.User.UserId(), accessRightEntity);

            if (assigneeOperation == AccessRightsOperation.AccessDenied)
            {
                return;
            }

            var assignedOperation = await dbContext.Query<AccessRightsType>().FirstOrDefaultAsync(p => p.Id == resource.AccessRightTypeId);

            if (assignedOperation.Operation == AccessRightsOperation.AccessDenied)
            {
                if (assigneeOperation == AccessRightsOperation.FullAccess)
                    context.Succeed(requirement);
            }
            else
            {
                if (assigneeOperation >= assignedOperation.Operation)
                {
                    context.Succeed(requirement);
                }
            }
        }
    }
}
