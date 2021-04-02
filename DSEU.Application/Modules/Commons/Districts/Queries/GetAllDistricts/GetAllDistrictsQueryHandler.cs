using AutoMapper;
using AutoMapper.QueryableExtensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Commons.Districts.Dtos;
using DSEU.Domain.Entities.RealEstateRights.Cases;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.Districts.Queries.GetAllDistricts
{
    public class GetAllDistrictsQueryHandler : IRequestHandler<GetAllDistrictsQuery, IEnumerable<DistrictDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetAllDistrictsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DistrictDto>> Handle(GetAllDistrictsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<District>().ProjectTo<DistrictDto>(mapper.ConfigurationProvider));
        }
    }
}
