using DSEU.Domain.Entities.Persons;
using DSEU.Domain.Entities.RealEstates;
using DSEU.Domain.Entities.SubjectsOfRights;
using System;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.RealEstateRights
{
    /// <summary>
    /// Право на недвижимость
    /// </summary>
    public abstract class RealEstateRight : BaseEntity
    {
        public string Name { get; set; }
        /// <summary>
        /// право для регистрации
        /// </summary>
        public RealEstateRightReviewResult ReviewResult { get; set; }
        /// <summary>
        /// Дата подачи заявления
        /// </summary>

        public DateTime? StatementDate { get; set; }
        /// <summary>
        /// Недвижимость
        /// </summary>        
        public virtual RealEstate RealEstate { get; set; }
        public virtual RealEstateRightsApplicant Applicant { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }

    public class RealEstateRightsApplicant
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

    /// <summary>
    /// Право на собственность
    /// </summary>
    public class RealEstateOwnRight: RealEstateRight
    {

    }

    /// <summary>
    /// Право на аренду
    /// </summary>
    public class RealEstateRentRight : RealEstateRight
    {

    }
}
