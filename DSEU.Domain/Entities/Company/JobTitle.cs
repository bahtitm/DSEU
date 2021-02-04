using System.Collections.Generic;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Company
{
    /// <summary>
    /// Должности
    /// </summary>
    public class JobTitle : DatabookEntry
    {
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public void ReevaluateEmployeeDescription()
        {
            foreach (var employee in Employees)
            {
                employee.Description = Name;
            }
        }

        public void Remove()
        {
            foreach (var employee in Employees)
            {
                employee.Description = string.Empty;
            }
        }
    }
}
