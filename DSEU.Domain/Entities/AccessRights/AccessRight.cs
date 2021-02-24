using System.Collections.Generic;

namespace DSEU.Domain.Entities.AccessRights
{
    /// <summary>
    /// Права на различные обьекты
    /// </summary>
    public class AccessRight : BaseEntity
    {
        /// <summary>
        /// Типы права чтение и на запись
        /// </summary>
        public AccessRightType AccessRightType { get; set; }
        /// <summary>
        /// ид сущности
        /// </summary>
        public int? EntityId { get; set; }
        /// <summary>
        /// Для экземпляра
        /// </summary>
        public bool IsForInstance { get; set; }
        /// <summary>
        /// Сущности для которых дать доступ
        /// </summary>
        public ICollection<AccessRightEntry> AccessRightEntries { get; set; }

    }

    public class AccessRightEntry:BaseEntity
    {
    }

    public enum AccessRightType
    {
        Read,
        Write,
    }
}
