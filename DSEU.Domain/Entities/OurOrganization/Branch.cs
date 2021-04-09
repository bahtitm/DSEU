using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.OurOrganization
{
    public class Branch : DatabookEntry
    {
        public int DepartamentId { get; set; }
        public virtual Departament Departament { get; set; }
    }
}
