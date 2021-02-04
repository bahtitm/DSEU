using System.Collections.Generic;
using System.Threading.Tasks;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;


namespace DSEU.Application.Services.Interfaces
{
    public interface IRecipientService
    {
        Task<bool> IsAdmin(int recipientId);
        Task<AccessRightsOperation> GetEntityTypeOperation(int recipientId, EntityTypeGuid entityTypeGuid);
        
        /// <summary>
        /// Получить группы связанные с пользователем
        /// </summary>
        /// <param name="reipientId"></param>
        /// <returns></returns>
        Task<IEnumerable<int>> GetRecipientGroups(int reipientId);
        Task<bool> IsInRole(int recipientId, string role);
        Task<bool> IsAuditor(int recipientId);
        Task<IEnumerable<string>> GetRecipientRoles(int recipientId);
        Task<List<(EntityTypeGuid entityType, AccessRightsOperation operation)>> GetUserAccessRightsOperations(int recipientId);
        Task<bool> IsAnyAccessDenied(int recipientId, IEnumerable<EntityTypeGuid> entityTypes);
        /// <summary>
        /// Выявить сотрудников
        /// </summary>
        /// <param name="recipients"></param>
        /// <returns></returns>
        Task<IEnumerable<int>> SelectEmployees(IEnumerable<int> recipients);
        Task<IEnumerable<int>> SubordinateEmployees(int employeeId);
        Task<bool> HasSubordinateEmployees(int employeeId);
    }
}
