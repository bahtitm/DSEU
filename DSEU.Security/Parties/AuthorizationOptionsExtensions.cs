using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Policies;

namespace DSEU.Security.Parties
{
    public static class AuthorizationOptionsExtensions
    {
        public static void AddPartiesPolicies(this AuthorizationOptions options)
        {
            options.AddCounterpartyPolicies();
            options.AddContactsPolicies();
        }

        private static void AddCounterpartyPolicies(this AuthorizationOptions options)
        {
            foreach (var operation in GetAvailableOperations())
            {
                var (name, policy) = PermisionPolicyGenerator.GeneratePolicy(EntityTypeGuid.Counterparty, operation);
                options.AddPolicy(name, policy);
            }
        }

        private static void AddContactsPolicies(this AuthorizationOptions options)
        {
            foreach (var operation in GetAvailableOperations())
            {
                var (name, policy) = PermisionPolicyGenerator.GeneratePolicy(EntityTypeGuid.Contact, operation);
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
