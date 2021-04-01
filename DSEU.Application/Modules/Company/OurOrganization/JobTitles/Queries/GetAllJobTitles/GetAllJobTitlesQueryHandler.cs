using AutoMapper;
using AutoMapper.QueryableExtensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Company.OurOrganization.JobTitles.Dtos;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.JobTitles.Queries.GetAllJobTitles
{
    public class GetAllJobTitlesQueryHandler : IRequestHandler<GetAllJobTitlesQuery, IEnumerable<JobTitleDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllJobTitlesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<JobTitleDto>> Handle(GetAllJobTitlesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<JobTitle>().ProjectTo<JobTitleDto>(mapper.ConfigurationProvider));
        }
    }
}
