namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Учетная запись
    /// </summary>
    public class Login : DatabookEntry
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// Тип аутентификации
        /// </summary>
        //public AuthenticationType AuthenticationType { get; set; }
    }
}
