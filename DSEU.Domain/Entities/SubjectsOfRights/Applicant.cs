using DSEU.Domain.Entities.SubjectsOfRights.Persons;
using System;

namespace DSEU.Domain.Entities.SubjectsOfRights
{
    public class Applicant
    {

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string PlaceOfBirth { get; set; }
        /// <summary>
        /// Вид документа
        /// </summary>
        public IdentityDocumentType IdentityDocumentType { get; set; }
        /// <summary>
        /// Номер документа
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Дата выдачи
        /// </summary>
        public DateTime? IssueDate { get; set; }
        /// <summary>
        /// Вем выдан
        /// </summary>
        public string IssuedBy { get; set; }
        /// <summary>
        /// Гражданство
        /// </summary>
        public string Citizenship { get; set; }
        /// <summary>
        /// Прописка
        /// </summary>
        public string Registration { get; set; }
    }
}