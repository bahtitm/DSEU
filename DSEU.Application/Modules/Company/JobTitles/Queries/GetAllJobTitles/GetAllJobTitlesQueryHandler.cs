using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.Company;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.JobTitles.Queries.GetAllJobTitles
{
    public class GetAllJobTitlesQueryHandler : IRequestHandler<GetAllJobTitlesQuery, IEnumerable<JobTitleDto>>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllJobTitlesQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<JobTitleDto>> Handle(GetAllJobTitlesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<JobTitle>().ProjectTo<JobTitleDto>(mapper.ConfigurationProvider));
        }
    }
}
