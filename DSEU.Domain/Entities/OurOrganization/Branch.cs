using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Entities.RealEstateRights.Cases;

namespace DSEU.Domain.Entities.OurOrganization
{
    /// <summary>
    /// Отделение
    /// </summary>
    public class Branch : DatabookEntry
    {
        public int DepartamentId { get; set; }
        /// <summary>
        /// Департамент
        /// </summary>
        public virtual Department Department { get; set; }
        public int DistrictId { get; set; }
        /// <summary>
        /// Регион под велаятом (Этрап или города в статусе Этрапа)
        /// </summary>
        public virtual District District { get; set; }
    }
}
