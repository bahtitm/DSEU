namespace DSEU.Application.Dtos
{
    /// <summary>
    /// Недвижимость
    /// </summary>
    public class RealEstateDto : BaseEntityDto
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
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
        public int? CurrencyId { get; set; }
    }
}
