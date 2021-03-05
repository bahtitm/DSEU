namespace DSEU.Domain.Entities.RealEstateRights
{
    /// <summary>
    /// абстрактный класс документы основание на изменение
    /// </summary>
    public abstract class BasisForChangeDocument : BaseEntity
    {
        public DocumentType DocumentType { get; set; }
        public string Name { get; set; }

        public int RealEstateRightId { get; set; }
        /// <summary>
        /// Право на недвижимость
        /// </summary>
        public virtual RealEstateRight RealEstateRight { get; set; }
    }
}