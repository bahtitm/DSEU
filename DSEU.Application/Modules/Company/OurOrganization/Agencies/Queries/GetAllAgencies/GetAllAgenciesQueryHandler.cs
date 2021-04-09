using AutoMapper;
using AutoMapper.QueryableExtensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Company.OurOrganization.Agencies.Dtos;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Agencies.Queries.GetAgencyDetail
{
    public class GetAllAgenciesQueryHandler : IRequestHandler<GetAllAgenciesQuery, IEnumerable<AgencyDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllAgenciesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AgencyDto>> Handle(GetAllAgenciesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Agency>().ProjectTo<AgencyDto>(mapper.ConfigurationProvider));
        }
    }
}
