using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Infrastructure.Services
{
    public class RoleMemberService : IRoleMemberService
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IRecipientLinkService recipientLinkService;

        public RoleMemberService(IApplicationDbContext dbContext, IRecipientLinkService recipientLinkService)
        {
            this.dbContext = dbContext;
            this.recipientLinkService = recipientLinkService;
        }
        public async Task GrantRole(int memberId, string role)
        {
            var entity = await dbContext.Set<Role>().FirstOrDefaultAsync(p => p.Uid == role);
            await recipientLinkService.CreateRecipientLink<RoleRecipientLinks>(entity.Id, memberId);
        }

        public async Task GrantRoleIfNotExists(int memberId, string role)
        {
            if (!await IsInRole(memberId, role))
                await GrantRole(memberId, role);
        }

        public async Task<bool> IsInRole(int memberId, string role)
        {
            var entity = await dbContext.Set<Role>().FirstOrDefaultAsync(p => p.Uid == role);
            return await dbContext.Set<RoleRecipientLinks>().AnyAsync(p => p.GroupId == entity.Id && p.MemberId == memberId);
        }

        public async Task RemoveFromRole(int memberId, string role)
        {
            var entity = await dbContext.Set<Role>().FirstOrDefaultAsync(p => p.Uid == role);
            await recipientLinkService.RemoveRecipientLink<RoleRecipientLinks>(entity.Id, memberId);
        }

        public async Task RemoveFromRole(int memberId, int roleId)
        {
            var role = await dbContext.Set<Role>().FirstOrDefaultAsync(p => p.Id == roleId);
            await recipientLinkService.RemoveRecipientLink<RoleRecipientLinks>(role.Id, memberId);
        }

        public async Task RemoveFromRoleIfExists(int memberId, string role)
        {
            if (await IsInRole(memberId, role))
                await RemoveFromRole(memberId, role);
        }
    }
}
