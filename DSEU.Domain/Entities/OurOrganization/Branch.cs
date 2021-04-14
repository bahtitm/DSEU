using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Entities.RealEstateRights.Cases;

namespace DSEU.Domain.Entities.OurOrganization
{
    public class Branch : DatabookEntry
    {
        public int DepartamentId { get; set; }
        public virtual Departament Departament { get; set; }
        public int DistrictId { get; set; }
        public virtual District District { get; set; }
    }
}
