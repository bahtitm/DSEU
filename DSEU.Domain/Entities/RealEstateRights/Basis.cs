namespace DSEU.Domain.Entities.RealEstateRights
{
    /// <summary>
    /// документ основание для действий
    /// </summary>
    public abstract class Basis : BaseEntity
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