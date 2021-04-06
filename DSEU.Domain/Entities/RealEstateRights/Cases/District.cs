using DSEU.Domain.Entities.CoreEntities;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.RealEstateRights.Cases
{
    /// <summary>
    /// Регион под велаятом (Этрап или города в статусе Этрапа)
    /// </summary>
    public class District : DatabookEntry
    {
        /// <summary>
        /// Код теретории
        /// </summary>
        public int DistrictCode { get; set; }
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
        /// <summary>
        /// теретории под этрапам (могут быть шахери шахерче генеши)
        /// </summary>
        public virtual ICollection<Locality> Localities { get; set; }

    }
}