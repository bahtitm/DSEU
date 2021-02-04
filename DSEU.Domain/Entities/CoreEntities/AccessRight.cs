using System.Collections.Generic;

namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Право доступа на
    /// </summary>
    public class AccessRight : BaseEntity
    {
        public EntityTypeGuid EntityTypeGuid { get; set; }
        public int? EntityId { get; set; }
        /// <summary>
        /// Для экземпляра
        /// </summary>
        public bool IsForInstance { get; set; }
        public ICollection<AccessRightEntry> Entries { get; set; }
    }
}
