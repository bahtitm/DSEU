using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DSEU.Infrastructure.DataProtection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDSEUPersistentDataProtectionKeys(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DSEUDataProtectionKeysDbContext>((sp, options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDataProtection().PersistKeysToDbContext<DSEUDataProtectionKeysDbContext>();

            return services;
        }
    }
}
