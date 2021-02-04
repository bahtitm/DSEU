using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Constants;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.CoreEntities;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Modules.RoleMembers.Queries.GetAllRoleMembers
{
    public class GetAllRoleMembersQueryHandler : IRequestHandler<GetAllRoleMembersQuery, IEnumerable<RoleMemberDto>>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllRoleMembersQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RoleMemberDto>> Handle(GetAllRoleMembersQuery request, CancellationToken cancellationToken)
        {
            // Исключаем пользователей роли всех пользователей (SystemRoles.AllUsers)
            //  для снижения нагрузки, т.к и так понятно что это за роль
            var excludeRoles = await dbContext.Query<Role>().Where(p => p.Uid == SystemRoles.User)
                                                            .Select(p => p.Id).ToListAsync();

            return await Task.FromResult(dbContext.Query<RoleRecipientLinks>()
                                                  .Include(p => p.Member)
                                                  .Where(p => p.GroupId == request.RoleId && !excludeRoles.Contains(p.GroupId))
                                                  .ProjectTo<RoleMemberDto>(mapper.ConfigurationProvider));
        }
    }
}
