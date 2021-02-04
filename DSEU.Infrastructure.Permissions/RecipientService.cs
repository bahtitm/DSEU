using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
//todo history link
//using DSEU.Domain.Entities.Docflow;
using DSEU.Domain.Extensions;
using DSEU.Infrastructure.Permissions.Extensions;
using DSEU.Infrastructure.Permissions.Models;

namespace DSEU.Infrastructure.Permissions
{
    public class RecipientService : IRecipientService
    {
        private readonly IMemoryCache memoryCache;
        public RecipientService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public async Task<AccessRightsOperation> GetEntityTypeOperation(int recipientId, EntityTypeGuid entityTypeGuid)
        {
            RecipientAccessRightItem accessRightUserObject = await GetAccessRightObjectAsync(recipientId);
            var operation = accessRightUserObject.AccessRights.FirstOrDefault(p => p.entityType == entityTypeGuid);
            if (operation.Equals(default))
                return AccessRightsOperation.AccessDenied;
            return operation.operation;
        }

        private async Task<RecipientAccessRightItem> GetAccessRightObjectAsync(int recipientId)
        {
            string key = string.Format(CacheKeys.RecipientItem, recipientId);
            var accessRightUserObject = memoryCache.Get<RecipientAccessRightItem>(key);
            return accessRightUserObject;
        }

        public async Task<bool> IsAdmin(int recipientId)
        {
            return await IsInRole(recipientId, SystemRoles.Admin);
        }

        public async Task<bool> IsAuditor(int recipientId)
        {
            return await IsInRole(recipientId, SystemRoles.Auditor);
        }

        public async Task<bool> IsInRole(int recipientId, string roleName)
        {
            var accessRightUserObject = await GetAccessRightObjectAsync(recipientId);
            return accessRightUserObject.IncludeInGroups.OfType<RoleAccessRightItem>().Any(p => p.Uid == roleName);
        }

        public async Task<IEnumerable<int>> GetRecipientGroups(int recipientId)
        {
            var accessRightUserObject = await GetAccessRightObjectAsync(recipientId);
            return accessRightUserObject.IncludeInGroups.Select(p => p.Id).Concat(new[] { recipientId });
        }

        public async Task<IEnumerable<string>> GetRecipientRoles(int recipientId)
        {
            var accessRightUserObject = await GetAccessRightObjectAsync(recipientId);
            return accessRightUserObject.IncludeInGroups.OfType<RoleAccessRightItem>().Select(p => p.Uid);
        }

        public async Task<List<(EntityTypeGuid, AccessRightsOperation)>> GetUserAccessRightsOperations(int recipientId)
        {
            var accessRightUserObject = await GetAccessRightObjectAsync(recipientId);
            return accessRightUserObject.AccessRights.Where(p => p.operation != AccessRightsOperation.Registration || p.operation != AccessRightsOperation.Approval).ToList();
        }

        //todo histroy link
        //public async Task<bool> CanRegisterDocument(int recipientId, DocumentTypeGuid documentTypeGuid)
        //{
        //    var operations = await GetDocumentOperations(recipientId, documentTypeGuid);
        //    if (operations.Any())
        //    {
        //        return operations.All(operation => operation != AccessRightsOperation.AccessDenied)
        //                && operations.Any(operation => operation == AccessRightsOperation.Registration);
        //    }
        //    return false;
        //}

        //public async Task<bool> CanCreateDocument(int recipientId, DocumentTypeGuid documentTypeGuid)
        //{
        //    var operations = await GetDocumentOperations(recipientId, documentTypeGuid);
        //    if (operations.Any())
        //    {

        //        return operations.All(operation => operation != AccessRightsOperation.AccessDenied)
        //            && operations.Any(operation => operation >= AccessRightsOperation.Create);
        //    }
        //    return false;
        //}

        //public async Task<bool> CanDeleteDocument(int recipientId, DocumentTypeGuid documentTypeGuid)
        //{
        //    var operations = await GetDocumentOperations(recipientId, documentTypeGuid);
        //    if (operations.Any())
        //    {
        //        return operations.All(operation => operation != AccessRightsOperation.AccessDenied)
        //            && operations.Any(operation => operation == AccessRightsOperation.DeleteDocument);
        //    }
        //    return false;
        //}

        //private async Task<IEnumerable<AccessRightsOperation>> GetDocumentOperations(int recipientId, DocumentTypeGuid documentTypeGuid)
        //{
        //    var hierarchy = documentTypeGuid.MapToEntityType().GetFullTypeHierarchy();
        //    var operations = await GetEntitiesOperations(recipientId, hierarchy);
        //    return operations;
        //}
        public async Task<bool> IsAnyAccessDenied(int recipientId, IEnumerable<EntityTypeGuid> entityTypes)
        {
            var operations = await GetEntitiesOperations(recipientId, entityTypes);
            return operations.Any(operation => operation == AccessRightsOperation.AccessDenied);
        }

        public async Task<IEnumerable<int>> SelectEmployees(IEnumerable<int> recipients)
        {
            if (recipients == null)
                return Array.Empty<int>();

            var items = memoryCache.Get<IEnumerable<RecipientAccessRightItem>>(CacheKeys.AllRecipients);
            var employees = items.OfType<EmployeeAccessRightItem>();
            var result = new List<int>(employees.Where(p => recipients.Contains(p.Id)).Select(p => p.Id));
            var employeeInGroups = items.OfType<EmployeeAccessRightItem>()
                .Where(p => p.IncludeInGroups.Any(p => recipients.Contains(p.Id)))?.Select(p => p.Id);
            result.AddRange(employeeInGroups);
            return result.Distinct();
        }

        private async Task<IEnumerable<AccessRightsOperation>> GetEntitiesOperations(int recipientId, IEnumerable<EntityTypeGuid> entities)
        {
            var accessRightUserObject = await GetAccessRightObjectAsync(recipientId);
            var accessRights = accessRightUserObject.AccessRights.Where(p => entities.Contains(p.entityType));
            return accessRights.Select(p => p.operation);
        }

        public async Task<IEnumerable<int>> SubordinateEmployees(int employeeId)
        {
            RecipientAccessRightItem accessRightUserObject = await GetAccessRightObjectAsync(employeeId);
            return accessRightUserObject.SubordinatedEmployees.Select(p => p.Id);
        }

        public async Task<bool> HasSubordinateEmployees(int employeeId)
        {
            RecipientAccessRightItem accessRightUserObject = await GetAccessRightObjectAsync(employeeId);
            return accessRightUserObject.SubordinatedEmployees.Any();
        }
    }
}