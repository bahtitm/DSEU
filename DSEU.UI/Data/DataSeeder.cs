using DSEU.Domain.Entities;
using DSEU.Infrastructure.Persistence;
using DSEU.UI.Data.DataMigrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DSEU.UI.Data
{
    public class DataSeeder
    {
        private readonly IEnumerable<IAppVersionDataMigration> appVersionMigrations;
        private readonly ILogger<DataSeeder> logger;
        private readonly AppDbContext dbContext;
        private readonly IConfiguration configuration;

        public DataSeeder(AppDbContext dbContext, IConfiguration configuration,
            IEnumerable<IAppVersionDataMigration> appVersionMigrations,
            ILogger<DataSeeder> logger)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
            this.appVersionMigrations = appVersionMigrations;
            this.logger = logger;
        }

        public async Task SeedData()
        {
            var currentVersion = GetType().Assembly.GetName().Version;
            await dbContext.InvokeTransactionAsync(async () =>
            {
                if (!await dbContext.Set<AppInfo>().AnyAsync())
                {
                    string mainLanguage = configuration.GetValue<string>("Organization:MainLanguage") ?? "ru";
                    SwitchCulture(mainLanguage);
                    await MigrateVersions(appVersionMigrations);
                }
                else
                {
                    var appInfos = await dbContext.Set<AppInfo>().ToListAsync();
                    var lastAppInfo = appInfos.Last();
                    SwitchCulture(lastAppInfo.MainLanguage);
                    Version lastVersion = Version.Parse(lastAppInfo.InstalledVersion);
                    var unapliedMigrations = appVersionMigrations.Where(p => p.Version >= lastVersion && appInfos.All(k => k.MigrationName != p.GetType().Name));
                    await MigrateVersions(unapliedMigrations);
                }
            });
        }

        private void SwitchCulture(string cultureName)
        {
            CultureInfo.CurrentCulture = new CultureInfo(cultureName);
            CultureInfo.CurrentUICulture = new CultureInfo(cultureName);
        }

        private async Task MigrateVersions(IEnumerable<IAppVersionDataMigration> availableMigrations)
        {
            foreach (var migration in availableMigrations.OrderBy(p => p.Version).ThenBy(p => p.Order))
            {
                logger.LogInformation("Starting apply migration {migrationName}", migration.GetType().Name);
                await migration.MigrateData();
                await WriteAppInfo(migration);
                await dbContext.SaveChangesAsync();
                logger.LogInformation("Migration {migrationName} completed", migration.GetType().Name);
            }
        }

        private async Task WriteAppInfo(IAppVersionDataMigration migration)
        {
            string name = configuration.GetValue<string>("Organization:Name");

            await dbContext.Set<AppInfo>().AddAsync(new AppInfo
            {
                InstalledVersion = migration.Version.ToString(),
                MigrationName = migration.GetType().Name,
                MainLanguage = CultureInfo.CurrentCulture.Name,
                Name = name,
                InstallDate = DateTime.Now
            });
        }
    }
}
