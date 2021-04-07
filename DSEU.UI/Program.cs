using DSEU.Infrastructure.StateRegisterSearch.Configuration;
using DSEU.UI.Data;
using DSEU.UI.Data.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;
using System.Threading.Tasks;

namespace DSEU.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            await MigrateDatabases(scope);
            await SeedData(scope);
            await ElasticSearchConfiugure(scope);
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((context, builder) =>
               {
                   builder.AddEnvironmentVariables()
                          .AddJsonFile($"emailConfig.json", optional: true)
                          .AddJsonFile($"serilogconfig.{context.HostingEnvironment.EnvironmentName}.json", optional: true)
                          .AddJsonFile("serilogconfig.json");

                   if (context.HostingEnvironment.IsDevelopment())
                   {
                       builder.AddJsonFile($"identityconfig.{context.HostingEnvironment.EnvironmentName}.json", optional: true);
                   }
                   else
                   {
                       LoadConfigs(builder);
                   }
               })
               .ConfigureServices((builder, services) =>
               {
                   services.Configure<KestrelServerOptions>(builder.Configuration.GetSection("Kestrel"));
                   services.AddScoped<DatabaseMigrator>();
                   services.AddScoped<DataSeeder>();
                   services.AddScoped<ElasticSearchConfiguration>();
                   services.AddAppVersionManualMigrations();
               })
              .UseSerilog((context, configuration) =>
              {
                  configuration.Enrich.FromLogContext().ReadFrom.Configuration(context.Configuration);
              })
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              });


        private static void LoadConfigs(IConfigurationBuilder builder)
        {
            var files = Directory.GetFiles("/config", "*.json", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                builder.AddJsonFile(file);
            }
        }

        private static async Task MigrateDatabases(IServiceScope scope)
        {
            var databaseMigrator = scope.ServiceProvider.GetRequiredService<DatabaseMigrator>();
            await databaseMigrator.MigrateAsync();
        }

        private static async Task SeedData(IServiceScope scope)
        {
            DataSeeder dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
            await dataSeeder.SeedData();
        }

        private static async Task ElasticSearchConfiugure(IServiceScope scope)
        {
            ElasticSearchConfiguration elasticSearch = scope.ServiceProvider.GetRequiredService<ElasticSearchConfiguration>();
            await elasticSearch.CreateElasticSearchIndex();
        }
    }
}
