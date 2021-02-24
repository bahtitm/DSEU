namespace DSEU.Domain.Entities.RealEstates
{
    /// <summary>
    /// Абстрактный недвижимость
    /// </summary>
    public abstract class RealEstate : BaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Кадастровая цена
        /// </summary>
        public double CadastralCost { get; set; }
        /// <summary>
        /// Цена сделки
        /// </summary>
        public double DealCost { get; set; }
    }
}