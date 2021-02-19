using AutoMapper;
using DSEU.Application.Common.Behaviours;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DSEU.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDSEUApplicationCore(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
