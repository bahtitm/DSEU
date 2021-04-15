using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Statements.Commands;
using DSEU.Domain.Entities.SubjectsOfRights;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.SubjectsOfRights.Applicants.Queries.GetApplicantDetail
{
    public class GetApplicantDetailQueryHandler : IRequestHandler<GetApplicantDetailQuery, ApplicantDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetApplicantDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApplicantDto> Handle(GetApplicantDetailQuery request, CancellationToken cancellationToken)
        {
            var applicant = await dbContext.Set<Applicant>().FirstOrDefaultAsync(p => p.Id == request.Id);
            return mapper.Map<ApplicantDto>(applicant);
        }
    }
}
