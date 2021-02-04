using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Policies;

namespace DSEU.Security.Commons
{
    public static class AuthorizationOptionsExtensions
    {
        public static void AddCommonsPolicies(this AuthorizationOptions options)
        {
            options.AddCountryPolicies();
            options.AddRegionPolicies();
            options.AddLocalityPolicies();
            options.AddCurrencyPolicies();
        }

        private static void AddCountryPolicies(this AuthorizationOptions options)
        {
            foreach (var operation in GetAvailableOperations())
            {
                var (name, policy) = PermisionPolicyGenerator.GeneratePolicy(EntityTypeGuid.Country, operation);
                options.AddPolicy(name, policy);
            }
        }

        private static void AddRegionPolicies(this AuthorizationOptions options)
        {
            foreach (var operation in GetAvailableOperations())
            {
                var (name, policy) = PermisionPolicyGenerator.GeneratePolicy(EntityTypeGuid.Region, operation);
                options.AddPolicy(name, policy);
            }
        }

        private static void AddLocalityPolicies(this AuthorizationOptions options)
        {
            foreach (var operation in GetAvailableOperations())
            {
                var (name, policy) = PermisionPolicyGenerator.GeneratePolicy(EntityTypeGuid.Locality, operation);
                options.AddPolicy(name, policy);
            }
        }

        private static void AddCurrencyPolicies(this AuthorizationOptions options)
        {
            foreach (var operation in GetAvailableOperations())
            {
                var (name, policy) = PermisionPolicyGenerator.GeneratePolicy(EntityTypeGuid.Currency, operation);
                options.AddPolicy(name, policy);
            }
        }

        private static IEnumerable<AccessRightsOperation> GetAvailableOperations()
        {
            yield return AccessRightsOperation.Read;
            yield return AccessRightsOperation.Create;
            yield return AccessRightsOperation.Edit;
            yield return AccessRightsOperation.FullAccess;
        }
    }
}
