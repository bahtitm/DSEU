namespace DSEU.Domain.Entities.CoreEntities
{
    /// <summary>
    /// Папка
    /// </summary>
    public class Folder : FolderBase
    {
        /// <summary>
        /// Специальная папка
        /// </summary>
        public bool IsSpecial { get; set; }
        public EntityTypeGuid SpecialFolderType { get; set; }
    }

}
