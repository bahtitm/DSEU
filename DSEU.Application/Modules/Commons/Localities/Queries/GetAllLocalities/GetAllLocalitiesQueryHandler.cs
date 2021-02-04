using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.Commons;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Localities.Queries.GetAllLocalities
{
    public class GetAllLocalitiesQueryHandler : IRequestHandler<GetAllLocalitiesQuery, IEnumerable<LocalityDto>>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllLocalitiesQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<LocalityDto>> Handle(GetAllLocalitiesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<Locality>().ProjectTo<LocalityDto>(mapper.ConfigurationProvider));
        }
    }
}
