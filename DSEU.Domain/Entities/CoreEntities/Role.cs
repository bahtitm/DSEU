namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Роль
    /// </summary>
    public class Role : Recipient
    {
        /// <summary>
        /// Неизменяемый
        /// </summary>
        public bool Immutable { get; set; }
        /// <summary>
        /// Роль с одним участником
        /// </summary>
        public bool IsSingleUser { get; set; }
    }
}
