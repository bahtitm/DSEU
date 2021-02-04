using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Parties.CounterParts.Models;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.CounterParts.Queries.GetAllCounterPartsQuery
{
    public class GetAllCounterPartsQueryHandler : IRequestHandler<GetAllCounterPartsQuery, IEnumerable<CounterPartDto>>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllCounterPartsQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CounterPartDto>> Handle(GetAllCounterPartsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<Counterparty>().ProjectTo<CounterPartDto>(mapper.ConfigurationProvider));
        }
    }

}
