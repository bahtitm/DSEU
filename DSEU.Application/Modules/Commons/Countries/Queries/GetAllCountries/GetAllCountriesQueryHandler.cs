using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.Commons;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Modules.Commons.Countries.Queries.GetAllCountries
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryDto>>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllCountriesQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CountryDto>> Handle(GetAllCountriesQuery request,
            CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<Country>().ProjectTo<CountryDto>(mapper.ConfigurationProvider));
        }
    }
}
