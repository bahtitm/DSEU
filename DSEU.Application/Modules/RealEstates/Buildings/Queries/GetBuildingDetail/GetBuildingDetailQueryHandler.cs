using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.RealEstates.Buildings.Dtos;
using DSEU.Domain.Entities.RealEstates;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.RealEstates.Buildings.Queries.GetBuildingDetail
{
    public class GetBuildingDetailQueryHandler : IRequestHandler<GetBuildingDetailQuery, BuildingDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetBuildingDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<BuildingDto> Handle(GetBuildingDetailQuery request, CancellationToken cancellationToken)
        {
            var building = await dbContext.Set<Building>().FirstOrDefaultAsync(p => p.Id == request.Id);
            return mapper.Map<BuildingDto>(building);
        }
    }
}
