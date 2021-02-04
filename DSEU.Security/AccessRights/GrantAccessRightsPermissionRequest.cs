using DSEU.Domain.Entities;

namespace DSEU.Security.AccessRights
{
    public class GrantAccessRightsPermissionRequest
    {
        public GrantAccessRightsPermissionRequest(int recipientId, int entityId, int accessRightTypeId, EntityTypeGuid entityType)
        {
            RecipientId = recipientId;
            EntityId = entityId;
            AccessRightTypeId = accessRightTypeId;
            EntityType = entityType;
        }

        public int RecipientId { get; }
        public int EntityId { get; }
        public int AccessRightTypeId { get; }
        public EntityTypeGuid EntityType { get; }
    }
}
