using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Commons.Districts.Dtos;
using DSEU.Domain.Entities.RealEstateRights.Cases;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.Districts.Queries.GetDistrictDetail
{
    public class GetDistrictDetailQueryHandler : IRequestHandler<GetDistrictDetailQuery, DistrictDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDistrictDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<DistrictDto> Handle(GetDistrictDetailQuery request, CancellationToken cancellationToken)
        {
            var district = await dbContext.Set<District>().FirstOrDefaultAsync(p => p.Id == request.Id);
            return mapper.Map<DistrictDto>(district);
        }
    }
}
