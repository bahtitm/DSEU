using AutoMapper;
using AutoMapper.QueryableExtensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.RealEstates.Lands.Dtos;
using DSEU.Domain.Entities.RealEstates;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.RealEstates.Lands.Queries.GetAllLands
{
    public class GetAllLandsQueryHandler : IRequestHandler<GetAllLandsQuery, IEnumerable<LandDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllLandsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LandDto>> Handle(GetAllLandsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Land>().ProjectTo<LandDto>(mapper.ConfigurationProvider));
        }
    }
}
