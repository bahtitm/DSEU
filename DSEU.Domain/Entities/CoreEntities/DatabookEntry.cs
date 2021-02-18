namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Справочник
    /// </summary>
    public abstract class DatabookEntry : BaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
