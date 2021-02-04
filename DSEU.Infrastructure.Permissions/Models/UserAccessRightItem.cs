using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Permissions.Models
{
    public abstract class UserAccessRightItem : RecipientAccessRightItem
    {
        protected UserAccessRightItem() { }
        public UserAccessRightItem(User recipient) : base(recipient)
        {
        }
    }
}