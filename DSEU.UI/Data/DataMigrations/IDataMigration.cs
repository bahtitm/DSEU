using System;
using System.Threading.Tasks;

namespace DSEU.UI.Data.DataMigrations
{
    public interface IDataMigration
    {
        public float Order { get; }
        public Version Version { get; }
        Task Migrate();
        string Name => GetType().Name;
    }
}
