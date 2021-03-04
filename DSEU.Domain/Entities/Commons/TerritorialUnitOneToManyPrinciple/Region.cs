using DSEU.Domain.Entities.CoreEntities;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.Commons.TerritorialUnitOneToManyPrinciple
{
    /// <summary>
    /// Велаят
    /// </summary>
    public class Region : DatabookEntry
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        /// <summary>
        /// Этрапы
        /// </summary>
        public ICollection<District> Districts { get; set; }
    }
}
