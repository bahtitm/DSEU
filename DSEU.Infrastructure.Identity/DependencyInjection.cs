using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DSEU.Application.Common.Interfaces;
using DSEU.Infrastructure.Identity.Extensions;
using DSEU.Infrastructure.Identity.Localization;
using DSEU.Infrastructure.Identity.Validation;

namespace DSEU.Infrastructure.Identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDSEUIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDbContext>((sp, options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IIdentityService, IdentityService>();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters += " äşýňöüžçä";
            });

            services.Configure<PasswordValidationOptions>(configuration.GetSection("IdentityOptions:PasswordValidation"));

            services.AddDefaultIdentity<ApplicationUser>()
                    .AddErrorDescriber<MultilanguageIdentityErrorDescriber>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<IdentityDbContext>()
                    .AddUserManager<ApplicationUserManager<ApplicationUser>>()
                    .AddPasswordValidator<PasswordContainsUserNameValidator>()
                    .AddPasswordValidator<LastPasswordsRestrictionValidator>()
                    .AddDefaultTokenProviders();

            services.AddIdentityServer4(configuration);

            return services;
        }

    }
}
