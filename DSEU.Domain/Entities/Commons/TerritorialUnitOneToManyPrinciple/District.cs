using DSEU.Domain.Entities.CoreEntities;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.Commons.TerritorialUnitOneToManyPrinciple
{
    /// <summary>
    /// Регион под велаятом (Этрап или города в статусе Этрапа)
    /// </summary>
    public class District : DatabookEntry
    {
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
        /// <summary>
        /// теретории под этрапам (могут быть шахери шахерче генеши)
        /// </summary>
        public virtual ICollection<Locality> Localities { get; set; }

    }
}