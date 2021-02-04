using System;

namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Папка
    /// </summary>
    public abstract class FolderBase : BaseEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Автор
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// Создано
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Содержимое
        /// </summary>
        public EntityTypeGuid MainEntityType { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }
        public string Uid { get; set; }
        public User Author { get; set; }
    }
}
