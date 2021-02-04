namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Записи прав доступа
    /// </summary>
    public class AccessRightEntry : BaseEntity
    {
        public AccessRightsType AccessRightsType { get; set; }
        public int AccessRightsTypeId { get; set; }
        public Recipient Recipient { get; set; }
        public int RecipientId { get; set; }
        public int RootId { get; set; }
        public AccessRight Root { get; set; }
    }
}
