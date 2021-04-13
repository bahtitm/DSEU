using DSEU.Infrastructure.StateRegisterSearch.Configuration;
using DSEU.StateRegisterSearch.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DSEU.Infrastructure.StateRegisterSearch
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDSEUElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ElasticSearchConfiguration>();

            services.AddScoped<IStateRegisterSearchService, StateRegisterSearchService>();

            return services;
        }
    }
}
