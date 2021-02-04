using System;

namespace DSEU.Domain.Entities
{
    /// <summary>
    /// Информация о приложении
    /// </summary>
    public class AppInfo : BaseEntity
    {
        public string Name { get; set; }
        public string MainLanguage { get; set; }
        public string InstalledVersion { get; set; }
        public string MigrationName { get; set; }
        public DateTime InstallDate { get; set; }
    }
}
