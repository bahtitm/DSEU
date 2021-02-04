using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.EntityType.Requirements;

namespace DSEU.Security.EntityType.Handlers
{
    public class EntityTypeOperationRequirementHandler : AuthorizationHandler<EntityTypeOperationRequirement>
    {
        private readonly IRecipientService recipientService;

        public EntityTypeOperationRequirementHandler(IRecipientService recipientService)
        {
            this.recipientService = recipientService;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, EntityTypeOperationRequirement requirement)
        {
            int employeeId = context.User.UserId();
            if (await recipientService.IsAdmin(employeeId))
            {
                context.Succeed(requirement);
                return;
            }

            if (requirement.Operation == AccessRightsOperation.Read)
            {
                if (await recipientService.IsAuditor(employeeId))
                {
                    context.Succeed(requirement);
                    return;
                }
            }

            var operation = await recipientService.GetEntityTypeOperation(context.User.UserId(), requirement.EntityType);

            if (operation == AccessRightsOperation.AccessDenied)
            {
                return;
            }

            if (requirement.Operation == AccessRightsOperation.Read)
            {
                if (operation == AccessRightsOperation.Create || operation == AccessRightsOperation.Edit ||
                    operation == AccessRightsOperation.FullAccess)
                {
                    context.Succeed(requirement);
                    return;
                }
            }

            if (requirement.Operation == AccessRightsOperation.Create)
            {
                if (operation == AccessRightsOperation.Edit ||
                    operation == AccessRightsOperation.FullAccess)
                {
                    context.Succeed(requirement);
                    return;
                }
            }

            if (requirement.Operation == AccessRightsOperation.Edit)
            {
                if (operation == AccessRightsOperation.FullAccess)
                {
                    context.Succeed(requirement);
                    return;
                }
            }

            if (operation == requirement.Operation)
            {
                context.Succeed(requirement);
                return;
            }

            return;
        }


    }


}
