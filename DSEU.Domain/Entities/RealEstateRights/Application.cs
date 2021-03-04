using DSEU.Domain.Entities.OurOrganization;
using DSEU.Domain.Entities.Persons;
using DSEU.Domain.Entities.SubjectsOfRights;
using System;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.RealEstateRights
{
    /// <summary>
    /// Заявление
    /// </summary>
    public class Application : Document
    {
        /// <summary>
        /// Номер заявления
        /// </summary>
        public string Number { get; set; }
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
        public Employee Employee { get; set; }
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
        public List<string> Documents { get; set; }
        public string Description { get; set; }
    }
}