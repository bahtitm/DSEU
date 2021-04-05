using AutoMapper;
using AutoMapper.QueryableExtensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Dtos;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Queries.GetAllOrganizationalUnits
{
    public class GetAllOrganizationalUnitsQueryHandler : IRequestHandler<GetAllOrganizationalUnitsQuery, IEnumerable<OrganizationalUnitDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllOrganizationalUnitsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<OrganizationalUnitDto>> Handle(GetAllOrganizationalUnitsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<OrganizationalUnit>().ProjectTo<OrganizationalUnitDto>(mapper.ConfigurationProvider));
        }
    }
}
