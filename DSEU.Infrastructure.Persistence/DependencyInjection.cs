using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DSEU.Application.Common.Interfaces;

namespace DSEU.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDSEUPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                options.UseLazyLoadingProxies();
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<AppDbContext>());
            

            return services;
        }
    }
}
