using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Dtos;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Queries.GetOrganizationalUnitDetail
{
    public class GetOrganizationalUnitDetailQueryHandler : IRequestHandler<GetOrganizationalUnitDetailQuery, OrganizationalUnitDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetOrganizationalUnitDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<OrganizationalUnitDto> Handle(GetOrganizationalUnitDetailQuery request, CancellationToken cancellationToken)
        {
            var organizationalUnit = await dbContext.Set<OrganizationalUnit>().FirstOrDefaultAsync(p => p.Id == request.Id);
            return mapper.Map<OrganizationalUnitDto>(organizationalUnit);
        }
    }
}
