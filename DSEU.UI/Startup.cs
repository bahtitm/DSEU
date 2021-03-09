using DSEU.Application;
using DSEU.Application.Common.Interfaces;
using DSEU.Infrastructure;
using DSEU.Infrastructure.Identity;
using DSEU.Infrastructure.Persistence;
using DSEU.UI.Extensions;
using DSEU.UI.Resources;
using DSEU.UI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace DSEU.UI
{
    public class Startup
    {

        public IWebHostEnvironment Env { get; }
        public IConfiguration Configuration { get; }
        private const string AllowedDomainsCorsPolicy = "AllowedDomains";
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            //DataSourceLoadOptionsBase.StringToLowerDefault = true;
            Configuration = configuration;
            this.Env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDSEUApplicationCore()
                    .AddDSEUInfrastructureServices()
                    .AddDSEUPersistence(Configuration)
                    //.AddDSEUPersistentDataProtectionKeys(Configuration)
                    .AddDSEUIdentity(Configuration);

            services.AddValidatorsFromAssembly(typeof(Application.DependencyInjection).Assembly);

            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

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
                x.MultipartBodyLengthLimit = int.MaxValue;
            });

            services.AddSwagger();
            services.AddMemoryCache();
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
            app.UseCors(AllowedDomainsCorsPolicy);

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();


            app.UseSession();

            app.UseSwagger();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization();
                endpoints.MapRazorPages().RequireAuthorization();

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
