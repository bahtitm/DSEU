using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using DSEU.UI.Data.DataMigrations;

namespace DSEU.UI.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataMigrations(this IServiceCollection services)
        {
            var types = Assembly.GetExecutingAssembly().DefinedTypes
                .Where(p => !p.IsAbstract && !p.IsInterface && p.ImplementedInterfaces.Any(p => p.IsAssignableFrom(typeof(IAppVersionDataMigration))));

            foreach (var type in types)
            {
                services.AddScoped(typeof(IAppVersionDataMigration), type);
            }
        }
    }
}
