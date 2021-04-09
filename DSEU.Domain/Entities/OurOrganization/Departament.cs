using DSEU.Domain.Entities.CoreEntities;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.OurOrganization
{
    public class Departament : DatabookEntry
    {
        public int AgencyId { get; set; }
        public virtual Agency Agency { get; set; }
        public virtual IEnumerable<Branch> Branches { get; set; }
    }
}
