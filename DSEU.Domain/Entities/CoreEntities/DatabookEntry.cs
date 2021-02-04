namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Справочник
    /// </summary>
    public abstract class DatabookEntry : BaseEntity
    {
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
