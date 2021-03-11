using DSEU.Domain.Entities.CoreEntities;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.OurOrganization
{
    /// <summary>
    /// Должность
    /// </summary>
    public class JobTitle : DatabookEntry
    {
        public virtual ICollection<User> Users { get; set; }
    }
}