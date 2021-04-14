using DSEU.Domain.Entities.Commons;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Entities.OurOrganization;
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
        /// <summary>
        /// Велаят
        /// </summary>
        public virtual Region Region { get; set; }
        /// <summary>
        /// определенная територия 
        /// </summary>
        public virtual ICollection<TerritorialUnit> TerritorialUnits { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }

    }
}