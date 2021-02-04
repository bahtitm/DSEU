using Microsoft.Extensions.DependencyInjection;
using DSEU.Application.Services.Interfaces;

namespace DSEU.Infrastructure.Permissions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDSEUPermissions(this IServiceCollection services)
        {
            services.AddScoped<IRecipientService, RecipientService>();
            services.AddScoped<IPermissionCalculator, PermissionCalculator>();
            return services;
        }
    }
}
