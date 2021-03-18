using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace DSEU.UI.Data.DataMigrations.V_1.V1_0_0
{
    public class SystemUsersMigration : IDataMigration
    {
        public Version Version => new Version("1.0.0.0");
        public float Order => 0.3f;

        private readonly IIdentityService identityService;
        private readonly IConfiguration configuration;

        public SystemUsersMigration(IIdentityService identityService, IConfiguration configuration)
        {
            this.identityService = identityService;
            this.configuration = configuration;
        }

        public async Task Migrate()
        {
            var firstRunAdminLogin = configuration["FirstRun:AdminLogin"];
            var firstRunAdminEmail = configuration["FirstRun:AdminEmail"];
            var firstRunPassword = configuration["FirstRun:AdminPassword"];
                 
            var adminUserId = await identityService.CreateUserAsync(firstRunAdminLogin, firstRunAdminEmail, firstRunPassword, false);
            await identityService.AddToRoleAsync(adminUserId, SystemRoles.Admin);
        }
    }
}
