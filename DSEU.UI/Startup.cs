using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using DevExtreme.AspNet.Data;
using FluentValidation;

using Microsoft.AspNetCore.Cors.Infrastructure;


using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.FileProviders;

using System.Globalization;
using System.IO;
using DSEU.Application;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Resources;
using DSEU.Infrastructure;
using DSEU.Infrastructure.DataProtection;
//using DSEU.Infrastructure.DocumentTemplates;
using DSEU.Infrastructure.Identity;
//using DSEU.Infrastructure.Import;
//using DSEU.Infrastructure.Licensing;
//using DSEU.Infrastructure.Localization;
using DSEU.Infrastructure.Permissions;
using DSEU.Infrastructure.Persistence;
//using DSEU.Infrastructure.Reporting;
//using DSEU.Infrastructure.SignalR;
//using DSEU.Infrastructure.SignalR.Hubs;
//sing DSEU.Infrastructure.Storage.Minio;
using DSEU.Security.Extensions;
//using DSEU.UI.EventBus;
using DSEU.UI.Extensions;
using DSEU.UI.Middleware;
//using DSEU.UI.Models;
using DSEU.UI.Resources;
using DSEU.UI.Services;

namespace DSEU.UI
{
    public class Startup
    {

        public IWebHostEnvironment Env { get; }
        public IConfiguration Configuration { get; }
        private const string AllowedDomainsCorsPolicy = "AllowedDomains";
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            DataSourceLoadOptionsBase.StringToLowerDefault = true;
            Configuration = configuration;
            DSEUInstallContext.MainCulture = configuration.GetValue<CultureInfo>("Organization:MainLanguage");
            this.Env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDSEUApplicationCore()
                    //.AddLicensing()
                    .AddDSEUInfrastructureServices()
                    .AddDSEUPersistence(Configuration)
                    .AddDSEUPersistentDataProtectionKeys(Configuration)
                    //.AddDSEULocalization()
                    //.AddDSEUMinioDocumentStorageProvider(Configuration)
                    //.AddDSEUignalR(Configuration)
                    .AddDSEUIdentity(Configuration)
                    .AddDSEUSecurity()
                    .AddDSEUPermissions();
                    //.AddImportServices(); 
                    //.AddBackgroundServices(Configuration)
                    //.AddTemplateService()
                    //.AddDSEUReporting();


            services.AddValidatorsFromAssembly(typeof(Application.DependencyInjection).Assembly);

            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ICurrentHttpRequestService, CurrentHttpRequestService>();
            //services.AddScoped<IEmailSender, MailKitEmailSender>();
            //services.Configure<EmailOptions>(Configuration.GetSection("EmailOptions"));

            services.AddRequestLocalization();

            services.AddCors(ConfigureCors);

            services.AddControllers();

            services.AddRazorPages()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddDataAnnotationsLocalization(options =>
                    {
                        options.DataAnnotationLocalizerProvider = (type, factory) =>
                            factory.Create(typeof(DataAnotationResources));
                    });

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });

            services.AddSwagger();
            services.AddMemoryCache();
            //services.AddMassTransitRabbitMq(Env, Configuration);
            services.Configure<IdentityOptions>(Configuration.GetSection("IdentityOptions"));
            services.AddSession();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-local-development");
                app.UseForwardedHeaders();
            }
            else
            {
                app.UseExceptionHandler("/error-production");
                app.UseForwardedHeaders();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseRequestLocalization();
            app.UseCors(AllowedDomainsCorsPolicy);

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Env.ContentRootPath, "PrivateStaticFiles")),
                RequestPath = "/StaticFiles"
            });

            app.UseSession();

            app.UseSwagger();
            app.UseMustChangePasswordOnFirstLogin();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization();
                endpoints.MapRazorPages().RequireAuthorization();
                //endpoints.MapHub<AssignmentsNotificationHub>("/hubs/assignments").RequireAuthorization();
                //endpoints.MapHub<OnlineHub>("/hubs/online").RequireAuthorization();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });
        }

        private void ConfigureCors(CorsOptions options)
        {
            options.AddPolicy(AllowedDomainsCorsPolicy, builder =>
            {
                var tokenValidIssuers = new List<string>(Configuration.GetSection($"IdentityServer:TokenValidationParameters:ValidIssuers").Get<string[]>());
                if (Env.IsDevelopment())
                {
                    tokenValidIssuers.Add("http://localhost:3000");
                }
                builder.WithOrigins(tokenValidIssuers.ToArray()).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            });
        }
    }
}
