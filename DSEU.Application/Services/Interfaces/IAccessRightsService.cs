using System.Collections.Generic;
using System.Threading.Tasks;
using DSEU.Application.Dtos.CoreEntities;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Services.Interfaces
{
    public interface IAccessRightsService
    {
        Task<bool> Exists(AccessRightEntity entity, int recipientId);
        Task GrantPermission(int recipientId, EntityTypeGuid entityTypeGuid, AccessRightsOperation operation);
        Task UpdatePermission(int recipientId, EntityTypeGuid entityTypeGuid, AccessRightsOperation operation);
        Task RemovePermission(int recipientId, EntityTypeGuid entityTypeGuid);
        Task GrantAccessRight(AccessRightEntity entity, int grantee, AccessRightsOperation operation);
        Task GrantAccessRight(IEnumerable<AccessRightEntity> entities, IEnumerable<int> grantees, AccessRightsOperation operation);
        Task GrantAccessRight(AccessRightEntity entity, IEnumerable<int> grantees, AccessRightsOperation operation);
        Task GrantAccessRight(AccessRightEntity entity, int grantee, int accessRightTypeId);
        Task RevokeAccessRightEntry(int accessRightEntryId);
        Task UpdateAccessRight(int accessRightEntryId, int accessRightTypeId);
        Task<AccessRightsOperation> GetAccessRightInstancePriorityOperation(int recipientId, AccessRightEntity entity);
        /// <summary>
        /// TODO: Перенести в Modules -> Core entities -> Queries
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<AccessRightDto> GetAccessRight(AccessRightEntity entity);
        /// <summary>
        /// Получить перечень прав доступа для сущностей и возможные операции для них
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="recipientId"></param>
        /// <returns></returns>
        Task<IEnumerable<AccessRightEntityOperation>> GetAccessRightsOperationsForEntities(IEnumerable<AccessRightEntity> entities, int recipientId);
        Task<bool> AllExists(IEnumerable<AccessRightEntity> entities, IEnumerable<int> grantees, AccessRightsOperation minimumOperation);
    }
}
