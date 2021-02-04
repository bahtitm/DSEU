using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.Commons;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Currencies.Queries.GetAllCurrencies
{
    public class GetAllCurrenciesQueryHandler : IRequestHandler<GetAllCurrenciesQuery, IEnumerable<CurrencyDto>>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllCurrenciesQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CurrencyDto>> Handle(GetAllCurrenciesQuery request,
            CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<Currency>().ProjectTo<CurrencyDto>(mapper.ConfigurationProvider));
        }
    }
}
