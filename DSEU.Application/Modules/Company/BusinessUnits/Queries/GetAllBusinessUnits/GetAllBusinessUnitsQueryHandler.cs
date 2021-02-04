using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.Company;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.BusinessUnits.Queries.GetAllBusinessUnits
{
    public class GetAllBusinessUnitsQueryHandler : IRequestHandler<GetAllBusinessUnitsQuery, IEnumerable<BusinessUnitDto>>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllBusinessUnitsQueryHandler(IReadOnlyApplicationDbContext dbContext,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<BusinessUnitDto>> Handle(GetAllBusinessUnitsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<BusinessUnit>().ProjectTo<BusinessUnitDto>(mapper.ConfigurationProvider));
        }
    }
}
