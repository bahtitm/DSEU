using DSEU.Application.Common.Enums;
using DSEU.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DSEU.Infrastructure.Identity
{
    public class RoleManager : IRoleManager
    {
        private readonly RoleManager<ApplicationUser> roleManager;

        public RoleManager(RoleManager<ApplicationUser> roleManager)
        {
            this.roleManager = roleManager;
        }

        public Task CreateAsync(string role, IEnumerable<UserClaimTypes> claims)
        {
            throw new NotImplementedException();
        }
    }
}
