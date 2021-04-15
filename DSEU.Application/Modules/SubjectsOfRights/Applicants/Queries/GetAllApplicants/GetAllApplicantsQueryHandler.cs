using AutoMapper;
using AutoMapper.QueryableExtensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Statements.Commands;
using DSEU.Domain.Entities.SubjectsOfRights;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.SubjectsOfRights.Applicants.Queries.GetAllApplicants
{
    public class GetAllApplicantsQueryHandler : IRequestHandler<GetAllApplicantsQuery, IEnumerable<ApplicantDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetAllApplicantsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ApplicantDto>> Handle(GetAllApplicantsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Applicant>().ProjectTo<ApplicantDto>(mapper.ConfigurationProvider));
        }
    }
}
