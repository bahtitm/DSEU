using DSEU.Domain.Entities.RealEstateRights;

namespace DSEU.Application.Dtos
{
    /// <summary>
    /// абстрактный класс документы основание на изменение
    /// </summary>
    public abstract class BasisForChangeDocumentDto : BaseEntityDto
    {
        public DocumentType DocumentType { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Право на недвижимость
        /// </summary>
        public int RealEstateRightId { get; set; }
    }
}
