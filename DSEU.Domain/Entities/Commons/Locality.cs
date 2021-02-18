using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Commons
{
    /// <summary>
    /// 
    /// </summary>
    public class Locality : DatabookEntry
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}
