using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DSEU.Infrastructure.Identity
{
    public class ApplicationUserManager<TUser> : UserManager<TUser>, IDisposable where TUser : class
    {
        private readonly IdentityDbContext dbContext;

        public ApplicationUserManager(IUserStore<TUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<TUser> passwordHasher,
            IEnumerable<IUserValidator<TUser>> userValidators,
            IEnumerable<IPasswordValidator<TUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<TUser>> logger,
            IdentityDbContext dbContext) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators,
                keyNormalizer, errors, services, logger)
        {
            this.dbContext = dbContext;
        }

        public override async Task<IdentityResult> ChangePasswordAsync(TUser user, string currentPassword, string newPassword)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync();

            var result = await base.ChangePasswordAsync(user, currentPassword, newPassword);
            if (result.Succeeded)
            {
                await WritePasswordHistory(user, newPassword);
            }

            await transaction.CommitAsync();

            return result;

        }

        public override async Task<IdentityResult> ResetPasswordAsync(TUser user, string token, string newPassword)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync();
            var result = await base.ResetPasswordAsync(user, token, newPassword);
            if (result.Succeeded)
            {
                await WritePasswordHistory(user, newPassword);
            }
            await transaction.CommitAsync();
            return result;
        }

        public override async Task<IdentityResult> AddPasswordAsync(TUser user, string password)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync();
            var result = await base.AddPasswordAsync(user, password);
            if (result.Succeeded)
            {
                await WritePasswordHistory(user, password);
            }
            await transaction.CommitAsync();
            return result;
        }

        public override async Task<IdentityResult> CreateAsync(TUser user, string password)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync();
            var result = await base.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await WritePasswordHistory(user, password);
            }
            await transaction.CommitAsync();
            return result;
        }

        private async Task WritePasswordHistory(TUser user, string newPassword)
        {
            var userId = await Store.GetUserIdAsync(user, CancellationToken);
            await dbContext.Set<UserPasswordHistory>().AddAsync(new UserPasswordHistory
            {
                PasswordHash = PasswordHasher.HashPassword(user, newPassword),
                UserId = userId
            });
            await dbContext.SaveChangesAsync();
        }

    }
}
