using DSEU.Domain.Entities.RealEstates;
using System;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.RealEstateRights
{
    /// <summary>
    /// регистрация прав
    /// </summary>
    public class RegistrationOfRights : BaseEntity
    {
        /// <summary>
        /// право для регистрации
        /// </summary>
        public RealEstateRight RealEstateRight { get; set; }
        public RealEstateRightReviewResult ReviewResult { get; set; }
        /// <summary>
        /// Дата подачи заявления
        /// </summary>
        public DateTime? StatementDate { get; set; }
        /// <summary>
        /// Недвижимость
        /// </summary>
        public virtual RealEstate RealEstate { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}