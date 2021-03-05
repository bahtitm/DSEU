using DSEU.Domain.Entities.Commons;

namespace DSEU.Domain.Entities.RealEstateRights
{
    /// <summary>
    /// Сделка
    /// </summary>
    public class Deal : BasisForChangeDocument
    {
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Условие
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// Цена сделки
        /// </summary>
        public double Cost { get; set; }
        public virtual Currency Currency { get; set; }
    }
}