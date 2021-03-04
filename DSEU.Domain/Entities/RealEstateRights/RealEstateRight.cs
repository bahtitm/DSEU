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
        public virtual Applicant Applicant { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
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
