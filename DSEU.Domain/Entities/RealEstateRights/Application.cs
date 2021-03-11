using DSEU.Domain.Entities.OurOrganization;
using DSEU.Domain.Entities.SubjectsOfRights;
using System;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.RealEstateRights
{
    /// <summary>
    /// Заявление
    /// </summary>
    public class Application : BaseEntity
    {
        /// <summary>
        /// Номер заявления
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// порядковый номер в журнале
        /// </summary>
        public int? SerialNumber { get; set; }
        /// <summary>
        /// Цель заявление
        /// </summary>
        public string PurposeAplication { get; set; }
        /// <summary>
        /// Время заявления (dd.MM.yyyy HH:mm)
        /// </summary>
        public DateTime? DateTime { get; set; }
        /// <summary>
        /// Отделение принявшее заявление
        /// </summary>
        public OrganizationalUnit OurOrganizationUnit { get; set; }
        /// <summary>
        /// Регистратор
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Заявитель
        /// </summary>
        public Applicant Applicant { get; set; }
        /// <summary>
        /// Представитель
        /// </summary>
        public ICollection<Applicant> Representatives { get; set; }
        /// <summary>
        /// Принятые документы от заявителя
        /// </summary>
        public List<string> AcceptedDocuments { get; set; }
        /// <summary>
        /// Выданные документы
        /// </summary>
        public List<string> IssuedDocuments { get; set; }
        /// <summary>
        /// Принятое Решение
        /// </summary>
        public string Decision { get; set; }
        public string Description { get; set; }

    }
}