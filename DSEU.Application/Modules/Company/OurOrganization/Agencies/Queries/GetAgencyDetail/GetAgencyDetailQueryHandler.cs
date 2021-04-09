using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Company.OurOrganization.Agencies.Dtos;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Agencies.Queries.GetAgencyDetail
{
    public class GetAgencyDetailQueryHandler : IRequestHandler<GetAgencyDetailQuery, AgencyDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAgencyDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<AgencyDto> Handle(GetAgencyDetailQuery request, CancellationToken cancellationToken)
        {
            var agency = await dbContext.Set<Agency>().FirstOrDefaultAsync(p => p.Id == request.id, cancellationToken);
            return mapper.Map<AgencyDto>(agency);
        }
    }
}
