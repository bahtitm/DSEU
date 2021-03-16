using DSEU.UI.Data.DataMigrations;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace DSEU.UI.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppVersionManualMigrations(this IServiceCollection services)
        {
            var types = Assembly.GetExecutingAssembly().DefinedTypes
                .Where(p => !p.IsAbstract && !p.IsInterface && p.ImplementedInterfaces.Any(p => p.IsAssignableFrom(typeof(IDataMigration))));

            foreach (var type in types)
            {
                services.AddScoped(typeof(IDataMigration), type);
            }
        }
    }
}
