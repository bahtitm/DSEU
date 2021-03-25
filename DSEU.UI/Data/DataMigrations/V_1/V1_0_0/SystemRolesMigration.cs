using DSEU.Application.Common.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace DSEU.UI.Data.DataMigrations.V_1.V1_0_0
{
    public class SystemRolesMigration : IDataMigration
    {
        public Version Version => new Version("1.0.0.0");
        public float Order => 0.1f;
        private readonly RoleManager<IdentityRole> roleManager;

        public SystemRolesMigration(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task Migrate()
        {
            await roleManager.CreateAsync(new IdentityRole(SystemRoles.Admin));
            await roleManager.CreateAsync(new IdentityRole(SystemRoles.User));
            await roleManager.CreateAsync(new IdentityRole(SystemRoles.Auditor));
            await roleManager.CreateAsync(new IdentityRole(SystemRoles.Registrar));
            await roleManager.CreateAsync(new IdentityRole(SystemRoles.Archiver));            
        }
    }
}