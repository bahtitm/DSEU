using DSEU.Domain.Entities.CoreEntities;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.Commons.TerritorialUnitOneToManyPrinciple
{
    /// <summary>
    /// Страна
    /// </summary>
    public class Country : DatabookEntry
    {
        /// <summary>
        /// Велаяты
        /// </summary>
        public virtual ICollection<Region> Regions { get; set; }
    }
}