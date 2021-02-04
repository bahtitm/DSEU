using DSEU.Domain.Entities.Company;

namespace DSEU.Infrastructure.Permissions.Models
{
    public class DepartmentAccessRightItem : GroupAccessRightItem
    {
        protected DepartmentAccessRightItem() { }
        public DepartmentAccessRightItem(Department recipient) : base(recipient)
        {
            ManagerId = recipient.ManagerId;
        }
        public int? ManagerId { get; set; }
    }
}