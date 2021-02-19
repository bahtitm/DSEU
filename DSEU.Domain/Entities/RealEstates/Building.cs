namespace DSEU.Domain.Entities.RealEstates
{
    /// <summary>
    /// Строение
    /// </summary>
    public class Building : RealEstate
    {
        /// <summary>
        /// Строение
        /// </summary>
        public string InvertarNumber { get; set; }
        /// <summary>
        /// Жилой Плошадь
        /// </summary>
        public double LiveSquare { get; set; }
        /// <summary>
        /// Количество этажей
        /// </summary>
        public int FlatTotal { get; set; }
        /// <summary>
        /// Количество этажей
        /// </summary>
        public int RoomTotal { get; set; }
    }
}
