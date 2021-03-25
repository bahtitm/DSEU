using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Commons;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Commons.TerritorialUnits.Queries.GetDetail
{
    public class GetDetailTerritorialUnitQueryHandler : IRequestHandler<GetDetailTerritorialUnitQuery, TerritorialUnitDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetDetailTerritorialUnitQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<TerritorialUnitDto> Handle(GetDetailTerritorialUnitQuery request, CancellationToken cancellationToken)
        {
            var terrUnit = await dbContext.Set<TerritorialUnit>().FirstOrDefaultAsync(emp => emp.Id == request.Id);
            return mapper.Map<TerritorialUnitDto>(terrUnit);
        }
    }
}
