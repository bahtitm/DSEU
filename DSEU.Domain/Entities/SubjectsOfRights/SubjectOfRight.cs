namespace DSEU.Domain.Entities.SubjectsOfRights
{
    /// <summary>
    /// Субъект прав
    /// </summary>
    public class SubjectOfRight : BaseEntity
    {
        public string Name { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
    }
}
