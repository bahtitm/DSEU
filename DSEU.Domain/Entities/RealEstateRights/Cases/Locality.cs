using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.RealEstateRights.Cases
{
    /// <summary>
    /// Населенные пункты
    /// </summary>
    public class Locality : DatabookEntry
    {
        public int DistrictId { get; set; }

        public virtual District District { get; set; }

    }
}