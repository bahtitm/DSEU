using System;

namespace DSEU.Domain.Entities.Persons
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : BaseEntity
    {
        /// <summary>
        /// Имя 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// отчество
        /// </summary>
        public string MiddleName { get; set; }
        public string UserId { get; set; }
        public DateTime? Created { get; set; }
    }
}