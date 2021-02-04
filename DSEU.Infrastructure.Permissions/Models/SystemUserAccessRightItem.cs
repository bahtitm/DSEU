using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Permissions.Models
{
    public class SystemUserAccessRightItem : UserAccessRightItem
    {
        protected SystemUserAccessRightItem() { }
        public SystemUserAccessRightItem(SystemUser recipient) : base(recipient)
        {
        }
    }
}