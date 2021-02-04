using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
//using TTDoc.HostedService.LicenseChecker;
//using TTDoc.HostedService.TempTaskCleaner;
//using TTDoc.HosterServices.TempDocumentCleaner;

namespace DSEU.UI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        //public static IServiceCollection AddBackgroundServices(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddTempDocumentCleanerHostedService(configuration);
        //    services.AddTempTasksCleanerHostedService(configuration);
        //    services.AddLicenseCheckerHostedService();
        //    return services;
        //}

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v2", new OpenApiInfo { Title = "Netije API", Version = "v2" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
                config.EnableAnnotations();
            });
        }

        public static void AddRequestLocalization(this IServiceCollection services)
        {
            const string DefaultCulture = "ru";

            services.AddLocalization(options => options.ResourcesPath = "Resources");


            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
                {
                    if (context.Request.Path.StartsWithSegments("/api"))
                    {
                        return new AcceptLanguageHeaderRequestCultureProvider().DetermineProviderCultureResult(context);
                    }

                    return new CookieRequestCultureProvider().DetermineProviderCultureResult(context);
                }));

                var tkCulture = new CultureInfo("tk");
                tkCulture.NumberFormat.NumberDecimalSeparator = ".";
                tkCulture.NumberFormat.CurrencyGroupSeparator = ".";

                var ruCulture = new CultureInfo("ru");
                ruCulture.NumberFormat.NumberDecimalSeparator = ".";
                ruCulture.NumberFormat.CurrencyGroupSeparator = ".";

                var supportedCultures = new List<CultureInfo>
                {
                    tkCulture,
                    ruCulture
                };

                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.SetDefaultCulture(DefaultCulture);
            });
        }

    }


}
