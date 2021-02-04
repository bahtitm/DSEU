using System;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Группа
    /// </summary>
    public abstract class Group : Recipient
    {
        /// <summary>
        /// Родительская группа
        /// </summary>
        public Group Parent { get; set; }
        public int? ParentId { get; set; }
        /// <summary>
        /// Состав
        /// </summary>
        public ICollection<GroupRecipientLinks> RecipientLinks { get; set; } = new List<GroupRecipientLinks>();
    }
}
