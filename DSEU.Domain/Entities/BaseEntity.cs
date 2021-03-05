using System.Collections.Generic;

namespace DSEU.Domain.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// ИД
        /// </summary>
        public int Id { get; set; }
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();        
    }
}