using DSEU.Application.Common.Interfaces;
using DSEU.Infrastructure.ElasticSearch.Configuration;
using DSEU.Infrastructure.ElasticSearch.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DSEU.Infrastructure.ElasticSearch
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDSEUElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ElasticSearchConfiguration>();

            services.AddScoped<IStateRegisterSearchService, StateRegisterSearchService>();
            services.AddScoped<IElasticSearchConnect, ElasticSearchConnect>();

            return services;
        }
    }
}
