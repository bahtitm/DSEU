using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Company.OurOrganization.Branches.Dtos;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Branches.Queries.GetBranchDetail
{
    public class GetBranchDetailQueryHandler : IRequestHandler<GetBranchDetailQuery, BranchDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetBranchDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<BranchDto> Handle(GetBranchDetailQuery request, CancellationToken cancellationToken)
        {
            var branch = await dbContext.Set<Branch>().FirstOrDefaultAsync(p => p.Id == request.id);
            return mapper.Map<BranchDto>(branch);
        }
    }
}
