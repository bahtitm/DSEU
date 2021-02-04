using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using DSEU.Infrastructure.Identity.Localization.Resources;

namespace DSEU.Infrastructure.Identity.Validation
{
    public class LastPasswordsRestrictionValidator : IPasswordValidator<ApplicationUser>
    {
        private readonly DSEUIdentityDbContext dbContext;
        private readonly PasswordValidationOptions options;
        public LastPasswordsRestrictionValidator(DSEUIdentityDbContext dbContext,
            IOptions<PasswordValidationOptions> options)
        {
            this.dbContext = dbContext;
            this.options = options.Value;
        }
        public async Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            var history = await dbContext.UserPasswordHistory.Where(p => p.UserId == user.Id)
                .OrderByDescending(p => p.Id)
                .Take(options.NumberOfDistinctLastPasswordsInHistory)
                .ToListAsync();

            if (history.Any(p => manager.PasswordHasher.VerifyHashedPassword(user, p.PasswordHash, password) == PasswordVerificationResult.Success))
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "LastPasswordsRestrictionValidatorError",
                    Description = string.Format(IdentityResource.LastPasswordsRestrictionValidatorError, options.NumberOfDistinctLastPasswordsInHistory)
                });
            }
            return IdentityResult.Success;
        }
    }
}
