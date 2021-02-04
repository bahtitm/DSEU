using Microsoft.AspNetCore.Authorization;
using System.Collections;
using System.Collections.Generic;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Policies;

namespace DSEU.Security.CoreEntities
{
    public static class AuthorizationOptionsExtensions
    {
        public static void AddCoreEntitiesPolicies(this AuthorizationOptions options)
        {
            options.AddCertificatePolicies();
        }

        private static void AddCertificatePolicies(this AuthorizationOptions options)
        {
            foreach (var operation in GetAvailableOperations())
            {
                var (name, policy) = PermisionPolicyGenerator.GeneratePolicy(EntityTypeGuid.Certificate, operation);
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
