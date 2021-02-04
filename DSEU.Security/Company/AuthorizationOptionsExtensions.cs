using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Security.Policies;

namespace DSEU.Security.Company
{
    public static class AuthorizationOptionsExtensions
    {
        public static void AddCompanyPolicies(this AuthorizationOptions options)
        {
            options.AddBusinessUnitPolicies();
            options.AddDepartmentPolicies();
            options.AddEployeePolicies();
            options.AddJobTitlesPolicies();
            options.AddManagersAssistantsPolicies();
        }

        private static void AddBusinessUnitPolicies(this AuthorizationOptions options)
        {
            foreach (var operation in GetAvailableOperations())
            {
                var (name, policy) = PermisionPolicyGenerator.GeneratePolicy(EntityTypeGuid.BusinessUnit, operation);
                options.AddPolicy(name, policy);
            }
        }

        private static void AddDepartmentPolicies(this AuthorizationOptions options)
        {
            foreach (var operation in GetAvailableOperations())
            {
                var (name, policy) = PermisionPolicyGenerator.GeneratePolicy(EntityTypeGuid.Department, operation);
                options.AddPolicy(name, policy);
            }
        }

        private static void AddEployeePolicies(this AuthorizationOptions options)
        {
            foreach (var operation in GetAvailableOperations())
            {
                var (name, policy) = PermisionPolicyGenerator.GeneratePolicy(EntityTypeGuid.Employee, operation);
                options.AddPolicy(name, policy);
            }
        }

        private static void AddJobTitlesPolicies(this AuthorizationOptions options)
        {
            foreach (var operation in GetAvailableOperations())
            {
                var (name, policy) = PermisionPolicyGenerator.GeneratePolicy(EntityTypeGuid.JobTitle, operation);
                options.AddPolicy(name, policy);
            }
        }

        private static void AddManagersAssistantsPolicies(this AuthorizationOptions options)
        {
            foreach (var operation in GetAvailableOperations())
            {
                var (name, policy) = PermisionPolicyGenerator.GeneratePolicy(EntityTypeGuid.ManagersAssistant, operation);
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
