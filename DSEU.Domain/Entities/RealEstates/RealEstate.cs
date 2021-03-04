using DSEU.Domain.Entities.Commons;
using DSEU.Domain.Entities.RealEstateRights;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.RealEstates
{
    /// <summary>
    /// Недвижимость
    /// </summary>
    public abstract class RealEstate : BaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// Цель
        /// </summary>
        public string Purpose { get; set; }
        /// <summary>
        /// Кадастровая цена
        /// </summary>
        public decimal? CadastralCost { get; set; }
        /// <summary>
        /// Цена сделки
        /// </summary>
        public decimal? DealCost { get; set; }
        /// <summary>
        /// Валюта
        /// </summary>
        public Currency Currency { get; set; }
        public int? CurrencyId { get; set; }
        public virtual ICollection<RealEstateRight> Rights { get; set; }
    }
}