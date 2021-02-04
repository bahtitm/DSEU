using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos;

namespace DSEU.Application.Modules.ActiveUsers.Queries.GetAllActiveUsers
{
    public class GetAllActiveUsersQueryHandler : IRequestHandler<GetAllActiveUsersQuery, IEnumerable<ActiveUser>>
    {
        private readonly IActiveUserManager activeUserManager;

        public GetAllActiveUsersQueryHandler(IActiveUserManager activeUserManager)
        {
            this.activeUserManager = activeUserManager;
        }

        public async Task<IEnumerable<ActiveUser>> Handle(GetAllActiveUsersQuery request, CancellationToken cancellationToken)
        {
            return await activeUserManager.GetActiveUsersAsync();
        }
    }
}
