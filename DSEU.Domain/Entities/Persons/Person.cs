﻿namespace DSEU.Domain.Entities.Persons
{
    /// <summary>
    /// Личность
    /// </summary>
    public class Person : BaseEntity
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
        public Passport Passport { get; set; }
        /// <summary>
        /// Прописка
        /// </summary>
        public string Registration { get; set; }
        /// <summary>
        /// Гражданство
        /// </summary>
        public string Citizenship { get; set; }
        public PersonStatus PersonStatus { get; set; }
    }
}