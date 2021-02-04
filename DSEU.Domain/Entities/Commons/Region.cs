using System.Collections.Generic;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Commons
{
    /// <summary>
    /// Регион
    /// </summary>
    public class Region : DatabookEntry
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Locality> Localities { get; set; }
    }
}
