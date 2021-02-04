using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Permissions.Models
{
    public class RoleAccessRightItem : GroupAccessRightItem
    {
        protected RoleAccessRightItem() { }
        public RoleAccessRightItem(Role recipient) : base(recipient)
        {

        }
    }
}