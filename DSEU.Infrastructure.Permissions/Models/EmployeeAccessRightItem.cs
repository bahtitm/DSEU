using System.Collections.Generic;
using System.Linq;
using DSEU.Application.Common.Extensions;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Permissions.Models
{
    public class EmployeeAccessRightItem : UserAccessRightItem, IEqualityComparer<EmployeeAccessRightItem>
    {
        protected EmployeeAccessRightItem() { }
        public EmployeeAccessRightItem(Employee recipient) : base(recipient)
        {
            DepartmentId = recipient.DepartmentId.Value;
        }
        public int? DepartmentId { get; }

        internal void Subordinate(IEnumerable<EmployeeAccessRightItem> subordinatedEmployees)
        {
            SubordinatedEmployees.AddRange(subordinatedEmployees.Distinct(this));
            AccessRights.TryAddRangeWithPriority(subordinatedEmployees.SelectMany(p => p.AccessRights).Distinct()
                .Where(p => p.operation != AccessRightsOperation.AccessDenied && p.operation != AccessRightsOperation.Registration).ToList());
        }

        public bool Equals(EmployeeAccessRightItem x, EmployeeAccessRightItem y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(EmployeeAccessRightItem obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}