using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.CoreEntities;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Extensions;

namespace DSEU.Application.Services
{
    public class AccessRightsService : IAccessRightsService
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;
        private readonly IRecipientService recipientService;

        public AccessRightsService(IApplicationDbContext dbContext,
            IRecipientService recipientService,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            this.dbContext = dbContext;
            this.recipientService = recipientService;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
        }

        public async Task GrantPermission(int recipientId, EntityTypeGuid entityTypeGuid, AccessRightsOperation operation)
        {
            await CreateAccessRightRootForTypeIfNotExists(entityTypeGuid);

            AccessRight accessRight = await dbContext.Set<AccessRight>().Include(p => p.Entries).FirstOrDefaultAsync(p => p.EntityTypeGuid == entityTypeGuid);
            accessRight.Entries.Add(new AccessRightEntry
            {
                RecipientId = recipientId,
                AccessRightsType = await FindAccessRightType(entityTypeGuid, operation, AccessRightsTypeArea.Type)
            });

            await dbContext.SaveChangesAsync();
        }

        private async Task CreateAccessRightRootForTypeIfNotExists(EntityTypeGuid entityTypeGuid)
        {
            if (!await dbContext.Set<AccessRight>().AnyAsync(p => p.EntityTypeGuid == entityTypeGuid))
            {
                await dbContext.Set<AccessRight>().AddAsync(new AccessRight
                {
                    EntityTypeGuid = entityTypeGuid,
                    IsForInstance = false,
                });
                await dbContext.SaveChangesAsync();
            }
        }

        private async Task<AccessRightsType> FindAccessRightType(EntityTypeGuid entityTypeGuid, AccessRightsOperation operation, AccessRightsTypeArea accessRightsTypeArea)
        {
            return await dbContext.Set<AccessRightsType>()
                                         .FirstOrDefaultAsync(p => p.AccessRightsTypeArea == accessRightsTypeArea
                                         && p.Operation == operation && p.EntityTypeGuid == entityTypeGuid && p.Status == Status.Active);
        }

        public async Task RemovePermission(int recipientId, EntityTypeGuid entityTypeGuid)
        {
            var accessRight = await dbContext.Set<AccessRight>().Include(p => p.Entries).FirstOrDefaultAsync(p => p.EntityTypeGuid == entityTypeGuid);
            var itemToRemove = accessRight.Entries.FirstOrDefault(p => p.RecipientId == recipientId);
            accessRight.Entries.Remove(itemToRemove);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdatePermission(int recipientId, EntityTypeGuid entityTypeGuid, AccessRightsOperation operation)
        {
            var accessRight = await dbContext.Set<AccessRight>().Include(p => p.Entries).FirstOrDefaultAsync(p => p.EntityTypeGuid == entityTypeGuid);
            var itemToUpdate = accessRight.Entries.FirstOrDefault(p => p.RecipientId == recipientId);
            itemToUpdate.AccessRightsType = await FindAccessRightType(entityTypeGuid, operation, AccessRightsTypeArea.Type);
            await dbContext.SaveChangesAsync();
        }

        public async Task<AccessRightsOperation> GetAccessRightInstancePriorityOperation(int recipientId, AccessRightEntity entity)
        {
            var dependentGroups = await recipientService.GetRecipientGroups(recipientId);

            var accessRight = await dbContext.Query<AccessRight>()
                .Include(p => p.Entries)
                .ThenInclude(p => p.AccessRightsType)
                .FirstOrDefaultAsync(p => p.EntityId == entity.EntityId && p.EntityTypeGuid == entity.EntityTypeGuid && p.IsForInstance);

            if (accessRight != null)
            {
                var entry = accessRight?.Entries.Where(p => dependentGroups.Contains(p.RecipientId));
                if (entry.Any())
                {
                    return entry.Max(p => p.AccessRightsType.Operation);
                }
            }

            if (await recipientService.IsAdmin(recipientId))
                return AccessRightsOperation.FullAccess;

            return AccessRightsOperation.AccessDenied;
        }

        public async Task GrantAccessRight(AccessRightEntity entity, int grantee, int accessRightTypeId)
        {
            await CreateAccessRightRootForInstanceIfNotExists(entity);

            var accessRightType = await dbContext.Query<AccessRightsType>().FirstOrDefaultAsync(p => p.Id == accessRightTypeId);

            await GrantAccessRight(entity, grantee, accessRightType.Operation);


        }

        public async Task GrantAccessRight(AccessRightEntity entity, int grantee, AccessRightsOperation operation)
        {
            await CreateAccessRightRootForInstanceIfNotExists(entity);
            await GrantAccessRight(new[] { entity }, new[] { grantee }, operation);
        }

        private async Task CreateAccessRightRootForInstanceIfNotExists(AccessRightEntity entity)
        {
            if (!await dbContext.Set<AccessRight>().AnyAsync(p => p.EntityId == entity.EntityId && p.EntityTypeGuid == entity.EntityTypeGuid && p.IsForInstance))
            {
                await dbContext.Set<AccessRight>().AddAsync(new AccessRight
                {
                    EntityId = entity.EntityId,
                    EntityTypeGuid = entity.EntityTypeGuid,
                    IsForInstance = true,
                });
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task GrantAccessRight(AccessRightEntity entity, IEnumerable<int> grantees, AccessRightsOperation operation)
        {
            await GrantAccessRight(new AccessRightEntity[] { entity }, grantees, operation);
        }
        public async Task GrantAccessRight(IEnumerable<AccessRightEntity> entities, IEnumerable<int> grantees, AccessRightsOperation operation)
        {
            if (entities == null)
                return;

            foreach (var entity in entities)
            {
                var accessRight = await dbContext.Set<AccessRight>()
                                           .Include(p => p.Entries)
                                           .ThenInclude(p => p.AccessRightsType)
                                           .FirstOrDefaultAsync(p => p.EntityId == entity.EntityId && p.EntityTypeGuid == entity.EntityTypeGuid);

                foreach (var grantee in grantees)
                {
                    if (accessRight.Entries.Any(p => p.RecipientId == grantee))
                    {
                        var oldAccessRightEntryItem = accessRight.Entries.First(p => p.RecipientId == grantee);
                        if (oldAccessRightEntryItem.AccessRightsType.Operation < operation)
                        {
                            oldAccessRightEntryItem.AccessRightsType = await FindAccessRightType(entity.EntityTypeGuid, operation, AccessRightsTypeArea.Instance);
                        }
                    }
                    else
                    {
                        accessRight.Entries.Add(new AccessRightEntry
                        {
                            RecipientId = grantee,
                            AccessRightsType = await FindAccessRightType(entity.EntityTypeGuid, operation, AccessRightsTypeArea.Instance)
                        });
                    }
                }
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(AccessRightEntity entity, int recipientId)
        {
            var recipientGroups = await recipientService.GetRecipientGroups(recipientId);

            return await dbContext.Set<AccessRight>()
                .Include(p => p.Entries)
                .AnyAsync(p => p.EntityId == entity.EntityId
                               && p.EntityTypeGuid == entity.EntityTypeGuid && p.IsForInstance
                               && p.Entries.Any(entry => recipientGroups.Contains(entry.RecipientId)));
        }
        public async Task RevokeAccessRightEntry(int accessRightEntryId)
        {
            var accessRightEntry = await dbContext.Set<AccessRightEntry>().Include(p => p.Root).FirstOrDefaultAsync(p => p.Id == accessRightEntryId);
            dbContext.Set<AccessRightEntry>().Remove(accessRightEntry);
            await dbContext.SaveChangesAsync();

        }

        public async Task UpdateAccessRight(int accessRightEntryId, int accessRightTypeId)
        {
            var accessRightEntry = await dbContext.Set<AccessRightEntry>()
                                            .Include(p => p.Root)
                                            .FirstOrDefaultAsync(p => p.Id == accessRightEntryId);
            accessRightEntry.AccessRightsTypeId = accessRightTypeId;
            await dbContext.SaveChangesAsync();
        }

        public async Task<AccessRightDto> GetAccessRight(AccessRightEntity entity)
        {
            var accessRight = await dbContext.Query<AccessRight>()
                                       .Include(p => p.Entries)
                                            .ThenInclude(p => p.Recipient)
                                       .Include(p => p.Entries)
                                            .ThenInclude(p => p.AccessRightsType)
                                       .FirstOrDefaultAsync(p => p.EntityTypeGuid == entity.EntityTypeGuid && p.EntityId == entity.EntityId && p.IsForInstance);

            AccessRightDto accessRightDto = new AccessRightDto();

            var priorityOperation = await GetAccessRightInstancePriorityOperation(currentUserService.UserId, entity);


            bool isAdmin = await recipientService.IsAdmin(currentUserService.UserId);

            var accessRightTypes = dbContext.Query<AccessRightsType>().Where(p => p.EntityTypeGuid == entity.EntityTypeGuid && p.Status == Status.Active && p.AccessRightsTypeArea == AccessRightsTypeArea.Instance);


            if (!isAdmin)
            {
                var availableOperations = priorityOperation.GetAvailableDocumentOperations();
                accessRightTypes = accessRightTypes.Where(p => availableOperations.Contains(p.Operation));
            }

            accessRightDto.AccessRightTypes = accessRightTypes.ProjectTo<AccessRightTypeDto>(mapper.ConfigurationProvider);

            accessRightDto.Entries = accessRight?.Entries.Select(p => new AccessRightEntryDto
            {
                Id = p.Id,
                AccessRightType = mapper.Map<AccessRightTypeDto>(p.AccessRightsType),
                Recipient = mapper.Map<AccessRightEntryRecipientDto>(p.Recipient),
                CanRemove = isAdmin || (priorityOperation == AccessRightsOperation.FullAccess && NotUniqFullAccess(accessRight, p.AccessRightsType.Operation)),
                CanUpdate = isAdmin || priorityOperation.CanUpdate() && PriorityOperationGreaterThanType(p.AccessRightsType, priorityOperation) && NotUniqFullAccess(accessRight, p.AccessRightsType.Operation)
            });

            return accessRightDto;
        }

        private bool PriorityOperationGreaterThanType(AccessRightsType entry, AccessRightsOperation priorityOperation)
        {
            return entry.Operation == AccessRightsOperation.AccessDenied || priorityOperation >= entry.Operation;
        }

        private bool NotUniqFullAccess(AccessRight accessRight, AccessRightsOperation accessRightsOperation)
        {
            if (accessRightsOperation != AccessRightsOperation.FullAccess)
                return true;

            return accessRight?.Entries.Count(p => p.AccessRightsType.Operation == accessRightsOperation) > 1;
        }

        public async Task<bool> AllExists(IEnumerable<AccessRightEntity> entities, IEnumerable<int> grantees, AccessRightsOperation minimumOperation)
        {
            var ids = entities.Select(p => p.EntityId).ToList();
            var entityTypes = entities.Select(p => p.EntityTypeGuid).ToList();

            var accessRights = await dbContext.Query<AccessRight>()
                .Where(p => p.IsForInstance && p.EntityId.HasValue && ids.Contains(p.EntityId.Value) && entityTypes.Contains(p.EntityTypeGuid))
                .Include(p => p.Entries)
                .ThenInclude(p => p.AccessRightsType)
                .ToListAsync();

            foreach (var entity in entities)
            {
                foreach (var recipient in grantees)
                {
                    var recipientGroups = await recipientService.GetRecipientGroups(recipient);

                    var attachmentAccessRight = accessRights.FirstOrDefault(p => p.EntityId == entity.EntityId);

                    if (attachmentAccessRight != null)
                    {
                        var entries = attachmentAccessRight.Entries.Where(p => recipientGroups.Contains(p.RecipientId));

                        if (entries.Any() && entries.All(p => p.AccessRightsType.Operation != AccessRightsOperation.AccessDenied) && entries.Any(p => p.AccessRightsType.Operation >= minimumOperation))
                            continue;
                    }
                    return false;
                }
            }

            return true;
        }

        public async Task<IEnumerable<AccessRightEntityOperation>> GetAccessRightsOperationsForEntities(IEnumerable<AccessRightEntity> entities, int recipientId)
        {
            if (await currentUserService.IsAdmin())
                return entities.Select(p => new AccessRightEntityOperation { Entity = p, Operation = AccessRightsOperation.FullAccess });

            var ids = entities.Select(p => p.EntityId).ToList();
            var entityTypes = entities.Select(p => p.EntityTypeGuid).ToList();

            var accessRights = dbContext.Query<AccessRight>();
            var accessRightEntries = dbContext.Query<AccessRightEntry>();
            var accessRightTypes = dbContext.Query<AccessRightsType>();

            var recipientGroups = await recipientService.GetRecipientGroups(recipientId);

            var result = from accessRight in accessRights
                         join accessRightEntry in accessRightEntries
                            on accessRight.Id equals accessRightEntry.RootId
                         join accessRightType in accessRightTypes
                            on accessRightEntry.AccessRightsTypeId equals accessRightType.Id
                         where accessRight.IsForInstance && recipientGroups.Contains(accessRightEntry.RecipientId) && ids.Contains(accessRight.EntityId.Value) && entityTypes.Contains(accessRight.EntityTypeGuid)
                         group new { accessRightType.Operation } by new { accessRight.EntityId, accessRight.EntityTypeGuid } into g
                         select new AccessRightEntityOperation { Entity = new AccessRightEntity(g.Key.EntityId.Value, g.Key.EntityTypeGuid), Operation = g.Max(p => p.Operation) };

            return await result.ToListAsync();
        }
    }
}
