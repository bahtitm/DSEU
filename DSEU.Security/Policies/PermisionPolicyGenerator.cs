using Microsoft.AspNetCore.Authorization;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.EntityType.Requirements;

namespace DSEU.Security.Policies
{
    public static class PermisionPolicyGenerator
    {
        public static (string name, AuthorizationPolicy policy) GeneratePolicy(EntityTypeGuid entityTypeGuid, AccessRightsOperation operation)
        {
            string name = GeneratePolicyName(entityTypeGuid, operation);
            AuthorizationPolicy policy = BuildAuthorizationPolicy(entityTypeGuid, operation);
            return (name, policy);
        }

        public static string GeneratePolicyName(EntityTypeGuid entityTypeGuid, AccessRightsOperation operation)
        {
            return $"{entityTypeGuid}_{operation}";
        }

        public static AuthorizationPolicy BuildAuthorizationPolicy(EntityTypeGuid entityTypeGuid, AccessRightsOperation operation)
        {
            AuthorizationPolicyBuilder builder = new AuthorizationPolicyBuilder();
            builder.AddRequirements(new EntityTypeOperationRequirement(operation, entityTypeGuid));
            return builder.Build();
        }
    }
}
