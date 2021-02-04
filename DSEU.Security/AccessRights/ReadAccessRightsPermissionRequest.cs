using DSEU.Domain.Entities;

namespace DSEU.Security.AccessRights
{
    public class ReadAccessRightsPermissionRequest
    {
        public ReadAccessRightsPermissionRequest(int entityId, EntityTypeGuid entityTypeGuid)
        {
            EntityId = entityId;
            EntityTypeGuid = entityTypeGuid;
        }

        public int EntityId { get; }
        public EntityTypeGuid EntityTypeGuid { get; }
    }
}
