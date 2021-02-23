using DSEU.Domain.Entities.RealEstates;
using System;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.RealEstateRights
{
    public class RealEstateRight : BaseEntity
    {
        public string Name { get; set; }
        /// <summary>
        /// Результат расмотрения
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

        public virtual ICollection<Document> Documents  { get; set; }        

    }
}
