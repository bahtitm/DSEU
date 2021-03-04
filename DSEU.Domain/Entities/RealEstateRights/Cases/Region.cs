using DSEU.Domain.Entities.CoreEntities;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.RealEstateRights.Cases
{
    /// <summary>
    /// Велаят
    /// </summary>
    public class Region : DatabookEntry
    {
        /// <summary>
        /// 01:03:02 тут 01(Ашгабат)
        /// </summary>
        public int RegionCode { get; set; }
        /// <summary>
        /// Этрапы
        /// </summary>
        public ICollection<District> Districts { get; set; }
    }
}