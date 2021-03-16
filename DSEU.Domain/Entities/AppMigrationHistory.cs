using System;

namespace DSEU.Domain.Entities
{
    /// <summary>
    /// Информация о приложении
    /// </summary>
    public class AppMigrationHistory : BaseEntity
    {
        public string InstalledVersion { get; set; }
        public string MigrationName { get; set; }
    }
}
