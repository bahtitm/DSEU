using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.OurOrganization;
using DSEU.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DSEU.UI.Data.DataMigrations.V_1.V1_0_0
{
    public class V1_0_0_0_SystemUsersMigration : IAppVersionDataMigration
    {
        private readonly ApplicationUserManager<ApplicationUser> userManager;
        private readonly IApplicationDbContext dbContext;

        public Version Version => new Version("1.0.0.0");
        public float Order => 0.1f;

        public V1_0_0_0_SystemUsersMigration(ApplicationUserManager<ApplicationUser> userManager, IApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public async Task MigrateData()
        {
            await CreateSystemUser(SystemUsers.Admin, new[] { SystemRoles.Admin, SystemRoles.Service }, "Password1!");
            await CreateSystemUser(SystemUsers.ServiceUser, new[] { SystemRoles.Service });
            await CreateSystemUser(SystemUsers.IntegrationService, new[] { SystemRoles.Service });
        }

        private async Task CreateSystemUser(string name, string[] roles, string password = "")
        {
            if (!await userManager.Users.AnyAsync(p => p.UserName == name))
            {
                var applicationUser = new ApplicationUser
                {
                    UserName = name,
                    Email = name
                };

                var result = await userManager.CreateAsync(applicationUser);

                if (!string.IsNullOrEmpty(password))
                    await userManager.AddPasswordAsync(applicationUser, password);

                var user = new User()
                {
                    UserId = applicationUser.Id,
                    Name = name,
                    Status = Status.Active,
                };
                await dbContext.AddAsync(user);

                await dbContext.SaveChangesAsync();
                await userManager.AddClaimAsync(applicationUser, new Claim(EmployeeClaimTypes.UserIdentifier, user.Id.ToString()));
            }
        }
    }
}
