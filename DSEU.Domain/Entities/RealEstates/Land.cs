namespace DSEU.Domain.Entities.RealEstates
{
    /// <summary>
    /// Земелный участок
    /// </summary>
    public class Land : RealEstate
    {
        /// <summary>
        /// Кадастровый номер
        /// </summary>
        public string CadastralNumber { get; set; }
        /// <summary>
        /// Мнимый кадастровый номер
        /// </summary>
        public string VirtualCadastralNumber { get; set; }
        /// <summary>
        /// Площадь
        /// </summary>
        public double Square { get; set; }

    }
}