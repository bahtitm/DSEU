using DSEU.Domain.Entities.CoreEntities;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.OurOrganization
{
    public class Agency : DatabookEntry
    {
        public virtual IEnumerable<Departament> Departaments { get; set; }
    }
}
