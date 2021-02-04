using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.CoreEntities;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.AccessRights.Requirements;

namespace DSEU.Security.AccessRights.Handlers
{
    public class ReadAccessRightsAuthorizationHandler : AuthorizationHandler<ReadAccessRightsRequirement, ReadAccessRightsPermissionRequest>
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IAccessRightsService accessRightsService;

        public ReadAccessRightsAuthorizationHandler(ICurrentUserService currentUserService, IAccessRightsService accessRightsService)
        {
            this.currentUserService = currentUserService;
            this.accessRightsService = accessRightsService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ReadAccessRightsRequirement requirement, ReadAccessRightsPermissionRequest resource)
        {
            if (await currentUserService.IsAdminOrAuditor())
            {
                context.Succeed(requirement);
                return;
            }

            var accessRightEntity = new AccessRightEntity(resource.EntityId, resource.EntityTypeGuid);
            var operation = await accessRightsService.GetAccessRightInstancePriorityOperation(context.User.UserId(), accessRightEntity);

            if (operation != AccessRightsOperation.AccessDenied)
            {
                context.Succeed(requirement);
            }
        }
    }
}
