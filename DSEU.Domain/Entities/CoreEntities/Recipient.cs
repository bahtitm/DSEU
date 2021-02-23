namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Субъект прав
    /// </summary>
    public abstract class Recipient : DatabookEntry
    {
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Служебный
        /// </summary>
        public bool IsSystem { get; set; }
        /// <summary>
        /// Идентификатор
        /// </summary>
        public string Uid { get; set; }
        private RecipientType recipientType;
        public RecipientType RecipientType => recipientType;
    }
}
