using AutoMapper;
using AutoMapper.QueryableExtensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Commons.Regions.Dtos;
using DSEU.Domain.Entities.RealEstateRights.Cases;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.Regions.Queries.GetAllRegions
{
    public class GetAllRegionsQueryHandler : IRequestHandler<GetAllRegionsQuery, IEnumerable<RegionDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllRegionsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RegionDto>> Handle(GetAllRegionsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Region>().ProjectTo<RegionDto>(mapper.ConfigurationProvider));
        }
    }
}
