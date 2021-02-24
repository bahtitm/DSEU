namespace DSEU.Domain.Entities.RealEstateRights
{
    /// <summary>
    /// абстрактный класс для Правоудостоверяющих и уточняющих документов
    /// </summary>
    public abstract class Document : BaseEntity
    {
        public DocumentType DocumentType { get; set; }
        public string Name { get; set; }
    }
}