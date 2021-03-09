using AutoMapper;
using AutoMapper.QueryableExtensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.RealEstates.Buildings.Dtos;
using DSEU.Domain.Entities.RealEstates;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.RealEstates.Buildings.Queries.GetAllBuildings
{
    public class GetAllBuildingsQueryHandler : IRequestHandler<GetAllBuildingsQuery, IEnumerable<BuildingDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllBuildingsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BuildingDto>> Handle(GetAllBuildingsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Building>().ProjectTo<BuildingDto>(mapper.ConfigurationProvider));
        }
    }
}
