using Microsoft.AspNetCore.Authorization;
using DSEU.Security.AccessRights.Requirements;
using DSEU.Security.Policies;

namespace DSEU.Security.AccessRights
{
    public static class AuthorizationOptionsExtensions
    {
        public static void AddPermissionsPolicy(this AuthorizationOptions options)
        {
            options.AddPolicy(AccessRightPolicy.Read, builder =>
            {
                builder.AddRequirements(new ReadAccessRightsRequirement());
            });

            options.AddPolicy(AccessRightPolicy.Grant, builder =>
            {
                builder.AddRequirements(new GrantAccessRightsRequirement());
            });

            options.AddPolicy(AccessRightPolicy.Revoke, builder =>
            {
                builder.AddRequirements(new RevokeAccessRightsRequirement());
            });

            options.AddPolicy(AccessRightPolicy.Update, builder =>
            {
                builder.AddRequirements(new UpdateAccessRightsRequirement());
            });
        }
    }
}
