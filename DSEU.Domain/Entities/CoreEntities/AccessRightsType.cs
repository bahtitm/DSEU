namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Тип прав доступа
    /// </summary>
    public class AccessRightsType : DatabookEntry
    {
        public string Name { get; set; }
        public EntityTypeGuid EntityTypeGuid { get; set; }
        public AccessRightsTypeArea AccessRightsTypeArea { get; set; }
        public AccessRightsOperation Operation { get; set; }
    }
}
