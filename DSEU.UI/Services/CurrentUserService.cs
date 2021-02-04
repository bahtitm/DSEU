using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Services.Interfaces;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.UI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IRecipientService recipientService;
        private readonly IReadOnlyApplicationDbContext dbContext;
        private int? switchedUserId;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor,
                                  IRecipientService recipientService,
                                  IReadOnlyApplicationDbContext dbContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.recipientService = recipientService;
            this.dbContext = dbContext;
        }

        public int UserId => GetUserId();


        private int GetUserId()
        {
            if (switchedUserId.HasValue)
            {
                return switchedUserId.Value;
            }
            return httpContextAccessor.HttpContext?.User?.UserId() ?? 0;
        }

        public async Task<bool> IsAdmin()
        {
            return await recipientService.IsAdmin(UserId);
        }

        public async Task<bool> IsAdminOrAuditor()
        {
            return await IsAdmin() || await recipientService.IsAuditor(UserId);
        }

        public async Task SwitchToServiceUser()
        {
            await SwitchToUser(SystemUsers.ServiceUser);
        }

        private async Task SwitchToUser(string userName)
        {
            var serviceUser = await dbContext.Query<User>()
                                             .Include(p => p.Login)
                                             .FirstOrDefaultAsync(p => p.Login.LoginName == userName);
            switchedUserId = serviceUser.Id;
        }


        public async Task<IEnumerable<int>> IncudeInGroups()
        {
            return await recipientService.GetRecipientGroups(UserId);
        }

    }
}
