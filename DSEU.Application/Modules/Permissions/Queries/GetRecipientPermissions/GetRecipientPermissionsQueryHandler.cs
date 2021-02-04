using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Modules.Permissions.Queries.GetRecipientPermissions
{
    public class GetRecipientPermissionsQueryHandler : IRequestHandler<GetRecipientPermissionsQuery, IEnumerable<RecipientPermissionDto>>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetRecipientPermissionsQueryHandler(IReadOnlyApplicationDbContext dbContext,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RecipientPermissionDto>> Handle(GetRecipientPermissionsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<AccessRightEntry>()
                                             .Include(p => p.AccessRightsType)
                                             .Where(p => p.AccessRightsType.AccessRightsTypeArea == AccessRightsTypeArea.Type && p.RecipientId == request.RecipientId)
                                             .ProjectTo<RecipientPermissionDto>(mapper.ConfigurationProvider));
        }
    }
}
