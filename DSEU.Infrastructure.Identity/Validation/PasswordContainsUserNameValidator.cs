using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DSEU.Infrastructure.Identity.Localization.Resources;

namespace DSEU.Infrastructure.Identity.Validation
{
    public class PasswordContainsUserNameValidator : IPasswordValidator<ApplicationUser>
    {

        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            if (password.ToLower().Contains(user.UserName))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "PasswordMustNotContainsUsername",
                    Description = IdentityResource.PasswordMustNotContainsUsernameValidationError
                }));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
