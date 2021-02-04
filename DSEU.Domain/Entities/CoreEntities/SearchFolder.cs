namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Папка поиска
    /// </summary>
    public class SearchFolder : FolderBase
    {
        /// <summary>
        /// Критерии поиска
        /// </summary>
        public string SearchCriteria { get; set; }
    }
}
