using Microsoft.AspNetCore.Authorization;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Security.EntityType.Requirements
{
    public class EntityTypeOperationRequirement : IAuthorizationRequirement
    {
        public EntityTypeOperationRequirement(AccessRightsOperation operation, EntityTypeGuid entityType)
        {
            Operation = operation;
            EntityType = entityType;
        }
        public EntityTypeGuid EntityType { get; }
        public AccessRightsOperation Operation { get; }
    }
}
