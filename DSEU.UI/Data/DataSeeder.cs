using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities;
using DSEU.UI.Data.DataMigrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSEU.UI.Data
{
    public class DataSeeder
    {
        private readonly IEnumerable<IDataMigration> appVersionMigrations;
        private readonly ILogger<DataSeeder> logger;
        private readonly IApplicationDbContext dbContext;

        public DataSeeder(IApplicationDbContext dbContext,
            IEnumerable<IDataMigration> appVersionMigrations,
            ILogger<DataSeeder> logger)
        {
            this.dbContext = dbContext;
            this.appVersionMigrations = appVersionMigrations;
            this.logger = logger;
        }

        public async Task SeedData()
        {
            var currentVersion = GetType().Assembly.GetName().Version;
            await dbContext.InvokeTransactionAsync(async () =>
            {
                if (!await dbContext.Set<AppMigrationHistory>().AnyAsync())
                {
                    await MigrateVersions(appVersionMigrations);
                }
                else 
                {
                    var migrations = await dbContext.Set<AppMigrationHistory>().ToListAsync();
                    var lastMigration = migrations.Last();
                    Version lastVersion = Version.Parse(lastMigration.InstalledVersion);
                    var unapliedMigrations = appVersionMigrations.Where(p => p.Version >= lastVersion && migrations.All(k => k.MigrationName != p.GetType().Name));
                    await MigrateVersions(unapliedMigrations);
                }
               
            });
        }

        private async Task MigrateVersions(IEnumerable<IDataMigration> availableMigrations)
        {
            foreach (var migration in availableMigrations.OrderBy(p => p.Version).ThenBy(p => p.Order))
            {
                try
                {
                    logger.LogInformation($"Starting apply migration: {migration.Name}");
                    await migration.Migrate();
                    await WriteMigrationHistory(migration);
                    await dbContext.SaveChangesAsync();
                    logger.LogInformation($"Migration: {migration.Name} - completed");
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Error occured in migration {migrationName}", migration.Name);
                    throw;
                }
            }
        }

        private async Task WriteMigrationHistory(IDataMigration migration)
        {
            await dbContext.Set<AppMigrationHistory>().AddAsync(new AppMigrationHistory
            {
                InstalledVersion = migration.Version.ToString(),
                MigrationName = migration.Name
            });
            
        }
    }
}
