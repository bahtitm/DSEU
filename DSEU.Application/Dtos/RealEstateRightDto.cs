using DSEU.Domain.Entities.RealEstateRights;
using System;

namespace DSEU.Application.Dtos
{
    /// <summary>
    /// Право на недвижимость
    /// </summary>
    public abstract class RealEstateRightDto : BaseEntityDto
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
        public int? RealEstateId { get; set; }
        public int? ApplicantId { get; set; }
    }
}
