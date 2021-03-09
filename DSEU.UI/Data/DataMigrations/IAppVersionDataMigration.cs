using System;
using System.Threading.Tasks;

namespace DSEU.UI.Data.DataMigrations
{
    public interface IAppVersionDataMigration
    {
        public float Order { get; }
        public Version Version { get; }
        Task MigrateData();
    }
}
