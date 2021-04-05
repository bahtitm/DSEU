using DSEU.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DSEU.Infrastructure.Report
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddReportingServices(this IServiceCollection services)
        {
            services.AddScoped<IReportGenerator, ReportGenerator>();

            return services;
        }
    }
}
