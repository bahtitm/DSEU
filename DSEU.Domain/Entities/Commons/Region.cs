using DSEU.Domain.Entities.CoreEntities;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.Commons
{
    /// <summary>
    /// Велаят либо город на правах Велаята (Ашгабат)
    /// </summary>
    public class Region : DatabookEntry
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Locality> Localities { get; set; }
    }
}
