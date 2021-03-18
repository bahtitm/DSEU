using DSEU.Domain.Entities.Commons.TerritorialUnitOneToManyPrinciple;
using DSEU.Domain.Entities.OurOrganization;
using DSEU.Domain.Entities.SubjectsOfRights;
using System;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.RealEstateRights
{
    /// <summary>
    /// Заявление
    /// </summary>
    public class Statement : BaseEntity
    {
        /// <summary>
        /// Порядковый номер в журнале
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Номер заявления
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Цель заявления
        /// </summary>
        public string Purpose { get; set; }
        /// <summary>
        /// Время заявления (dd.MM.yyyy HH:mm)
        /// </summary>
        public DateTime? DateTime { get; set; }
        /// <summary>
        /// Регистратор
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Заявитель
        /// </summary>
        public virtual Applicant Applicant { get; set; }
        /// <summary>
        /// Представитель
        /// </summary>
        public virtual ICollection<Applicant> Representatives { get; set; }
        /// <summary>
        /// Принятые документы от заявителя
        /// </summary>
        public List<string> AcceptedDocuments { get; set; }
        /// <summary>
        /// Выданные документы
        /// </summary>
        public List<string> IssuedDocuments { get; set; }
        /// <summary>
        /// Информация о недвижимости
        /// </summary>
        public string RealEstate { get; set; }
        /// <summary>
        /// Принятое Решение
        /// </summary>
        public Decision Decision { get; set; }
        public int? RealEstateRightId { get; set; }
        public virtual RealEstateRight RealEstateRight { get; set; }
        public int LocalityId { get; set; }
        public virtual Locality Locality { get; set; }
        public string Note { get; set; }
    }
}