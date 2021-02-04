using System.Collections.Generic;

namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Тип связи
    /// </summary>
    public class RelationType : DatabookEntry
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Имя при добавлении связи
        /// </summary>
        public string TargetDescription { get; set; }
        /// <summary>
        /// Имя при добавлении связи
        /// </summary>
        public string SourceDescription { get; set; }
        /// <summary>
        /// Имя источника
        /// </summary>
        public string SourceTitle { get; set; }
        /// <summary>
        /// Имя назначения
        /// </summary>
        public string TargetTitle { get; set; }
        /// <summary>
        /// Показывать источник выше по иерархии при отображении связей
        /// </summary>
        public bool HasDirection { get; set; }
        /// <summary>
        /// Показывать при добавлении связи
        /// </summary>
        public bool UseSource { get; set; }
        /// <summary>
        /// Показывать при добавлении связи
        /// </summary>
        public bool UseTarget { get; set; }
        public bool IsSystem { get; set; }
        /// <summary>
        /// Проверять права на изменение документа при добавлении связи
        /// </summary>
        public bool NeedSourceUpdateRights { get; set; }
        /// <summary>
        /// Параметры
        /// </summary>
        public ICollection<RelationTypeMapping> Mapping { get; set; }
    }
}
