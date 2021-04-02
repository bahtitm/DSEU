using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Commons.Regions.Dtos;
using DSEU.Domain.Entities.RealEstateRights.Cases;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.Regions.Queries.GetRegionDetail
{
    public class GetRegionDetailQueryHandler : IRequestHandler<GetRegionDetailQuery, RegionDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetRegionDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<RegionDto> Handle(GetRegionDetailQuery request, CancellationToken cancellationToken)
        {
            var region = await dbContext.Set<Region>().FirstOrDefaultAsync(p => p.Id == request.Id);
            return mapper.Map<RegionDto>(region);
        }
    }
}
