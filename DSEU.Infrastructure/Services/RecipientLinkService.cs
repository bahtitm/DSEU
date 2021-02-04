using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Services
{
    public class RecipientLinkService : IRecipientLinkService
    {
        private readonly IApplicationDbContext dbContext;

        public RecipientLinkService(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateRecipientLink<T>(int groupId, int memberId) where T : GroupRecipientLinks, new()
        {
            T recipientLink = new T()
            {
                GroupId = groupId,
                MemberId = memberId
            };
            await dbContext.AddAsync(recipientLink);
            await dbContext.SaveChangesAsync();
        }

        public async Task GrantRole(int memberId, string roleName)
        {
            var role = await dbContext.Set<Role>().FirstOrDefaultAsync(p => p.Name == roleName);
            await dbContext.Set<RoleRecipientLinks>().AddAsync(new RoleRecipientLinks { Group = role, MemberId = memberId });
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists<T>(int groupId, int memberId) where T : GroupRecipientLinks, new()
        {
            return await dbContext.Set<T>().AnyAsync(p => p.GroupId == groupId && p.MemberId == memberId);
        }

        public async Task RemoveRecipientLink<T>(int groupId, int memberId) where T : GroupRecipientLinks, new()
        {
            var recipientLink = await dbContext.Set<T>()
                                            .FirstOrDefaultAsync(p => p.GroupId == groupId && p.MemberId == memberId);
            dbContext.Set<T>().Remove(recipientLink);
            await dbContext.SaveChangesAsync();
        }
    }
}
