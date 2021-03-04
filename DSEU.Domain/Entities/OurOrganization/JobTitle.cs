using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Entities.Persons;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.OurOrganization
{
    /// <summary>
    /// Должности
    /// </summary>
    public class JobTitle : DatabookEntry
    {
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

        // TODO: Я создал это, но не понял для чего нужно
        public override string ToString()
        {
            return Name;
        }
    }
}
