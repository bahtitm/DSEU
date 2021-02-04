using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.Commons;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Regions.Queries.GetAllRegions
{
    public class GetAllRegionsQueryHandler : IRequestHandler<GetAllRegionsQuery, IEnumerable<RegionDto>>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllRegionsQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RegionDto>> Handle(GetAllRegionsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<Region>()
                                                  .ProjectTo<RegionDto>(mapper.ConfigurationProvider));
        }
    }
}
