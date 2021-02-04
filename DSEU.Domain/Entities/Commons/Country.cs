using System.Collections.Generic;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Commons
{
    /// <summary>
    /// Страна
    /// </summary>
    public class Country : DatabookEntry
    {
        public string Name { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}
