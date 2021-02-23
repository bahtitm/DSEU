using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSEU.Domain.Entities.AccessRights
{
    public class AccessRight:BaseEntity
    {
        public AccessRightType  AccessRightType { get; set; }
        public int? EntityId { get; set; }
        /// <summary>
        /// Для экземпляра
        /// </summary>
        public bool IsForInstance { get; set; }
        public ICollection<AccessRightEntry> Entries { get; set; }

    }

    public class AccessRightEntry
    {
    }

    public enum AccessRightType
    {
        Read,
        Write,
    }
}
