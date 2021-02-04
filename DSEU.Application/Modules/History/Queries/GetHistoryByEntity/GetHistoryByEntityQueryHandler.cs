using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.History.Models;
using DSEU.Domain.Entities.Content;

namespace DSEU.Application.Modules.History.Queries.GetHistoryByEntity
{
    public class GetHistoryByEntityQueryHandler : IRequestHandler<GetHistoryByEntityQuery, IEnumerable<HistoryDto>>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetHistoryByEntityQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<HistoryDto>> Handle(GetHistoryByEntityQuery request, CancellationToken cancellationToken)
        {
            return dbContext.Query<DocumentHistory>()
                            .Include(p => p.User)
                            .Where(p => p.EntityTypeGuid == request.EntityTypeGuid && p.EntityId == request.Id)
                            .ProjectTo<HistoryDto>(mapper.ConfigurationProvider);
        }
    }
}
