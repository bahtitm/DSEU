using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DSEU.UI.Data.DataMigrations.V_1.V1_0_0
{
    public class RoleClaimsMigration : IDataMigration
    {
        public Version Version => new Version("1.0.0.0");
        public float Order => 0.2f;
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleClaimsMigration(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task Migrate()
        {
            await AssignClaimToRole(SystemRoles.Admin, UserClaimTypes.ManipulateWithDataBookEntries.ToString(),
                                                       UserClaimTypes.UserRegistration.ToString(),
                                                       UserClaimTypes.UserClaimRoleRegistration.ToString());
        }

        private async Task AssignClaimToRole(string roleName, params string[] claims)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            foreach (var claim in claims)
            {
                var roleClaim = new Claim(claim, bool.TrueString);
                await roleManager.AddClaimAsync(role, roleClaim);
            }
        }
    }
}