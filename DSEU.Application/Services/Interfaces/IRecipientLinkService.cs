using System.Threading.Tasks;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Services.Interfaces
{
    public interface IRecipientLinkService
    {
        Task<bool> Exists<T>(int groupId, int memberId) where T : GroupRecipientLinks, new();
        Task CreateRecipientLink<T>(int groupId, int memberId) where T : GroupRecipientLinks, new();
        Task RemoveRecipientLink<T>(int groupId, int memberId) where T : GroupRecipientLinks, new();
    }
}
