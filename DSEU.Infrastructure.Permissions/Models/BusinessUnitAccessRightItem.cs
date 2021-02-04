using DSEU.Domain.Entities.Company;

namespace DSEU.Infrastructure.Permissions.Models
{
    public class BusinessUnitAccessRightItem : GroupAccessRightItem
    {
        protected BusinessUnitAccessRightItem() { }
        public BusinessUnitAccessRightItem(BusinessUnit recipient) : base(recipient)
        {
            CEO = recipient.CEO;
        }
        public int? CEO { get; set; }
    }
}