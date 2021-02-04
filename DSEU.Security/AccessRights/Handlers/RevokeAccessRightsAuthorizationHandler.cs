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
    public class RevokeAccessRightsAuthorizationHandler : AuthorizationHandler<RevokeAccessRightsRequirement, int>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly ICurrentUserService currentUserService;
        private readonly IAccessRightsService accessRightsService;

        public RevokeAccessRightsAuthorizationHandler(IReadOnlyApplicationDbContext dbContext,
            ICurrentUserService currentUserService, IAccessRightsService accessRightsService)
        {
            this.dbContext = dbContext;
            this.currentUserService = currentUserService;
            this.accessRightsService = accessRightsService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RevokeAccessRightsRequirement requirement, int accessRightEntryId)
        {
            var employeeId = context.User.UserId();
            if (await currentUserService.IsAdmin())
            {
                context.Succeed(requirement);
                return;
            }

            var accessRightEntry = await dbContext.Query<AccessRightEntry>().Include(p => p.Root).FirstOrDefaultAsync(p => p.Id == accessRightEntryId);
            var root = accessRightEntry.Root;

            var accessRightEntity = new AccessRightEntity(root.EntityId.Value, root.EntityTypeGuid);

            var operation = await accessRightsService.GetAccessRightInstancePriorityOperation(employeeId, accessRightEntity);

            if (operation == AccessRightsOperation.FullAccess)
            {
                context.Succeed(requirement);
            }
        }
    }
}
