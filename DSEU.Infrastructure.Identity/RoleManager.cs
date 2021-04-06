using AutoMapper;
using DSEU.Application.Common.Enums;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Company.OurOrganization.Role.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DSEU.Infrastructure.Identity
{
    public class RoleManager : IRoleManager
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;

        public RoleManager(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        public async Task CreateRoleAsync(string role, IEnumerable<UserClaimTypes> claims)
        {
            await roleManager.CreateAsync(new IdentityRole(role));

            var identityRole = await roleManager.FindByNameAsync(role);

            foreach (var claim in claims)
            {
                var roleClaim = new Claim(claim.ToString(), bool.TrueString);
                await roleManager.AddClaimAsync(identityRole, roleClaim);
            }
        }

        public async Task<IEnumerable<RoleDto>> GetAllRoles()
        {
            return await roleManager.Roles.Select(p => new RoleDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToListAsync();
        }

        public async Task<RoleDetailDto> GetRoleById(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var claims = await roleManager.GetClaimsAsync(role);

            var roleDto = new RoleDetailDto
            {
                Id = role.Id,
                Name = role.Name,
                Claims = claims.Select(p => p.Type)
            };

            return roleDto;
        }

        public async Task UpdateClaimsAsync(string id, IEnumerable<UserClaimTypes> claims)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var role = await roleManager.FindByIdAsync(id);
            var oldClaims = await roleManager.GetClaimsAsync(role);

            foreach (var claim in oldClaims)
            {
                await roleManager.RemoveClaimAsync(role, claim);
            }

            if (claims != null)
            {
                foreach (var claim in claims)
                {
                    var roleClaim = new Claim(claim.ToString(), bool.TrueString);
                    await roleManager.AddClaimAsync(role, roleClaim);
                }
            }
        }

        public async Task UpdateRoleNameAsync(string id, string roleName)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrEmpty(roleName))
                throw new ArgumentNullException(nameof(roleName));

            var role = await roleManager.FindByIdAsync(id);

            if (string.IsNullOrEmpty(role.Id))
            {
                throw new ArgumentNullException(nameof(role));
            }

            await roleManager.SetRoleNameAsync(role, roleName);
        }

        public async Task DeleteRoleAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            var role = await roleManager.FindByIdAsync(id);

            await roleManager.DeleteAsync(role);
        }
    }
}
