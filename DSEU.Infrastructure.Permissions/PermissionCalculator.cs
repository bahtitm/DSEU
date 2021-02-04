using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Infrastructure.Permissions.Extensions;
using DSEU.Infrastructure.Permissions.Models;

namespace DSEU.Infrastructure.Permissions
{
    public class PermissionCalculator : IPermissionCalculator
    {
        private readonly IMemoryCache memoryCache;
        private readonly IReadOnlyApplicationDbContext dbContext;
        public PermissionCalculator(IMemoryCache memoryCache, IReadOnlyApplicationDbContext dbContext)
        {
            this.memoryCache = memoryCache;
            this.dbContext = dbContext;
        }

        public async Task Calculate()
        {
            RecipientAccessRightItem.All.Clear();

            var recipients = dbContext.Query<Recipient>().Include("RecipientLinks")
                                                         .Include("Parent")
                                                         .Where(p => p.Status == Status.Active);

            var accessRightEntries = await dbContext.Query<AccessRightEntry>()
                                                .Include(p => p.AccessRightsType)
                                                .Join(recipients, ar => ar.RecipientId, recipient => recipient.Id, (ar, rec) => ar)
                                                .Where(p => p.AccessRightsType.AccessRightsTypeArea == AccessRightsTypeArea.Type).ToListAsync();

            CalculateRecipientOwnAccessRights(await recipients.ToListAsync(), accessRightEntries);
            ComputeGroupsAccessRights();
            ComputeBusinessUnitHeadAccessRights();
            ComputeDepartmentManagersAccessRights();

            Parallel.ForEach(RecipientAccessRightItem.All, async (item) =>
             {
                 var cacheKey = string.Format(CacheKeys.RecipientItem, item.Key);
                 memoryCache.Set(cacheKey, item.Value);
             });

            memoryCache.Set(CacheKeys.AllRecipients, RecipientAccessRightItem.All.Select(p => p.Value));

        }

        private void CalculateRecipientOwnAccessRights(IEnumerable<Recipient> recipients, IEnumerable<AccessRightEntry> accessRightEntries)
        {
            foreach (var recipient in recipients)
            {
                RecipientAccessRightItem accessRightUserObject = RecipientAccessRightItem.Create(recipient);
                var recipientAccessRights = accessRightEntries.Where(p => p.RecipientId == recipient.Id).Select(p => (p.AccessRightsType.EntityTypeGuid, p.AccessRightsType.Operation)).ToList();
                accessRightUserObject.AccessRights.TryAddRangeWithPriority(recipientAccessRights);
            }
        }

        private void ComputeGroupsAccessRights()
        {
            foreach (var group in RecipientAccessRightItem.All.Select(p => p.Value).OfType<GroupAccessRightItem>().Where(p => p.Members.Any()))
            {
                group.PullDownAccessRights();
            }
        }

        private void ComputeBusinessUnitHeadAccessRights()
        {
            foreach (var group in RecipientAccessRightItem.All.Select(p => p.Value).OfType<BusinessUnitAccessRightItem>().Where(p => p.CEO.HasValue))
            {
                var ceo = RecipientAccessRightItem.All[group.CEO.Value] as EmployeeAccessRightItem;
                var subordinatedGroups = RecipientAccessRightItem.All.Select(p => p.Value).OfType<EmployeeAccessRightItem>()
                    .Where(p => p.IncludeInGroups.Any(p => p.Id == group.Id));

                ceo.Subordinate(subordinatedGroups.Where(p => p.Id != ceo.Id));
            }
        }

        private void ComputeDepartmentManagersAccessRights()
        {
            foreach (var group in RecipientAccessRightItem.All.Select(p => p.Value).OfType<DepartmentAccessRightItem>().Where(p => p.ManagerId.HasValue))
            {
                var departmentManager = RecipientAccessRightItem.All[group.ManagerId.Value] as EmployeeAccessRightItem;
                var subordinatedGroups = RecipientAccessRightItem.All.Select(p => p.Value).OfType<EmployeeAccessRightItem>()
                    .Where(p => p.IncludeInGroups.Any(p => p.Id == group.Id));

                departmentManager.Subordinate(subordinatedGroups.Where(p => p.Id != departmentManager.Id));
            }
        }
    }
}