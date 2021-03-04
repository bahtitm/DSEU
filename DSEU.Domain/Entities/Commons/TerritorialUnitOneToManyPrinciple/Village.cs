using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Commons.TerritorialUnitOneToManyPrinciple
{
    /// <summary>
    /// Село
    /// </summary>
    public class Village : DatabookEntry
    {
        public int LocalityId { get; set; }
        public Locality Locality { get; set; }
    }
}