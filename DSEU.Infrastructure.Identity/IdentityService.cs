using DSEU.Application.Common.Exceptions;
using DSEU.Application.Common.Interfaces;
using DSEU.Shared;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly ApplicationUserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public IdentityService(ApplicationUserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<string> CreateUserAsync(string userName, string email, string password, bool needChangePassword = true, CancellationToken cancellationToken = default)
        {



            var user = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                EmailConfirmed = !string.IsNullOrEmpty(email),
                NeedChangePassword = needChangePassword,
                Created = SystemTime.Now()
            };
            var result = await userManager.CreateAsync(user, password);
            ThrowExceptionIfNotSuccess(result);

            return user.Id;
        }

        public async Task AddToClaimAsync(string userId, string claimType, string claimValue, CancellationToken cancellationToken = default)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            var claims = await userManager.GetClaimsAsync(user);
            if (!claims.Any(p => p.Type == claimType))
            {
                var result = await userManager.AddClaimAsync(user, new Claim(claimType, claimValue));
                ThrowExceptionIfNotSuccess(result);
            }
        }

        public async Task AddToClaimAsync(string userId, string claimType, int claimValue, CancellationToken cancellationToken = default)
        {
            await AddToClaimAsync(userId, claimType, claimValue.ToString(), cancellationToken);
        }

        public async Task LockUserAsync(string userId, DateTimeOffset? until, CancellationToken cancellationToken = default)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            var result = await userManager.SetLockoutEnabledAsync(user, true);
            ThrowExceptionIfNotSuccess(result);
            var lockResult = await userManager.SetLockoutEndDateAsync(user, until);
            ThrowExceptionIfNotSuccess(lockResult);
        }

        public async Task UnlockUserAsync(string userId, CancellationToken cancellationToken = default)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            var result = await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.Now.AddDays(-1));
            ThrowExceptionIfNotSuccess(result);
        }

        public async Task ChangeUserPassword(string userId, string newPassword, CancellationToken cancellationToken = default)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            var result = await userManager.RemovePasswordAsync(user);
            ThrowExceptionIfNotSuccess(result);
            var setPasswordResult = await userManager.AddPasswordAsync(user, newPassword);
            ThrowExceptionIfNotSuccess(setPasswordResult);
        }

        public async Task SetConfirmedEmailAsync(string userId, string email)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            user.Email = email;
            user.EmailConfirmed = true;
            var result = await userManager.UpdateAsync(user);
            ThrowExceptionIfNotSuccess(result);
        }

        public async Task UpdateUsernameAsync(string userId, string userName)
        {
            var user = await userManager.FindByIdAsync(userId);
            ThrowExceptionIfNull(userId, user);
            var result = await userManager.SetUserNameAsync(user, userName);
            ThrowExceptionIfNotSuccess(result);
        }

        private static void ThrowExceptionIfNull(string userId, ApplicationUser user)
        {
            if (user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), userId);
            }
        }

        public static void ThrowExceptionIfNotSuccess(IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                throw new ValidationException(identityResult.Errors.Select(prop => new ValidationFailure(prop.Code, prop.Description)));
            }
        }

        public async Task AddToRoleAsync(string userId, string roleName)
        {
            var user = await userManager.FindByIdAsync(userId);
            await userManager.AddToRoleAsync(user, roleName);
        }
    }
}
