using AutoMapper;
using AutoMapper.QueryableExtensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.TerritorialUnits.Queries.GetAll
{
    public class GetAllTerritorialUnitQueryHandler : IRequestHandler<GetAllTerritorialUnitQuery, IEnumerable<TerritorialUnitDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllTerritorialUnitQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<TerritorialUnitDto>> Handle(GetAllTerritorialUnitQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<TerritorialUnit>().ProjectTo<TerritorialUnitDto>(mapper.ConfigurationProvider));
        }
    }
}
