using System;

namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Замещение
    /// </summary>
    public class Substitution : DatabookEntry
    {
        
        /// <summary>
        /// Описание
        /// </summary>
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int SubstituteId { get; set; }
        /// <summary>
        /// Сотрудник
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Замещающий
        /// </summary>
        public User Substitute { get; set; }
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Дата окончания
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
