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
    public class UpdateAccessRightsAuthorizationHandler : AuthorizationHandler<UpdateAccessRightsRequirement, UpdateAccessRightsPermissionRequest>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly ICurrentUserService currentUserService;
        private readonly IAccessRightsService accessRightsService;

        public UpdateAccessRightsAuthorizationHandler(IReadOnlyApplicationDbContext dbContext,
            ICurrentUserService currentUserService, IAccessRightsService accessRightsService)
        {
            this.dbContext = dbContext;
            this.currentUserService = currentUserService;
            this.accessRightsService = accessRightsService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UpdateAccessRightsRequirement requirement, UpdateAccessRightsPermissionRequest resource)
        {
            var employeeId = context.User.UserId();
            if (await currentUserService.IsAdmin())
            {
                context.Succeed(requirement);
                return;
            }

            var accessRightEntry = await dbContext.Query<AccessRightEntry>().Include(p => p.Root).FirstOrDefaultAsync(p => p.Id == resource.AccessRightEntryId);
            var root = accessRightEntry.Root;
            var accessRightEntity = new AccessRightEntity(root.EntityId.Value, root.EntityTypeGuid);
            var assigneeOperation = await accessRightsService.GetAccessRightInstancePriorityOperation(employeeId, accessRightEntity);

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
