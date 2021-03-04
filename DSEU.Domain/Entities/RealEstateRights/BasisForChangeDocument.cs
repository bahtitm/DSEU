namespace DSEU.Domain.Entities.RealEstateRights
{
    /// <summary>
    /// абстрактный класс для Правоудостоверяющих и уточняющих документов
    /// </summary>
    public abstract class BasisForChangeDocument : BaseEntity
    {
        public DocumentType DocumentType { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Право на недвижимость
        /// </summary>
        public virtual RealEstateRight RealEstateRight { get; set; }
    }
}