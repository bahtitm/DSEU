///using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Infrastructure.Services;

namespace DSEU.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDSEUInfrastructureServices(this IServiceCollection services)
        {
            //services.AddTransient<IDocumentRegisterNumberFormatService, DocumentRegisterNumberFormatService>();

            //services.AddScoped<IDocumentRegisterNumberingService, DocumentRegisterNumberingService>();

            services.AddScoped<IRoleMemberService, RoleMemberService>();
            services.AddScoped<IRecipientLinkService, RecipientLinkService>();
            services.AddSingleton<IRegistrationIndexExtractor, RegistrationIndexExtractor>();
            services.AddScoped<IEmployeePhotoService, EmployeePhotoService>();
            

            return services;
        }
    }
}
