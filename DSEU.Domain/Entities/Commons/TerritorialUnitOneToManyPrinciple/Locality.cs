using DSEU.Domain.Entities.CoreEntities;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.Commons.TerritorialUnitOneToManyPrinciple
{
    /// <summary>
    /// Населенные пункты
    /// </summary>
    public class Locality : DatabookEntry
    {
        public int DistrictId { get; set; }

        public virtual District District { get; set; }

        public virtual ICollection<Village> Villages { get; set; }
    }
}