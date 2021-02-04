namespace DSEU.Security.AccessRights
{
    public class UpdateAccessRightsPermissionRequest
    {
        public UpdateAccessRightsPermissionRequest(int accessRightEntryId, int accessRightTypeId)
        {
            AccessRightEntryId = accessRightEntryId;
            AccessRightTypeId = accessRightTypeId;
        }

        public int AccessRightEntryId { get; }
        public int AccessRightTypeId { get; }
    }    
}
