using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Parties.Organizations.Companies.Models;

namespace DSEU.Application.Modules.Parties.Organizations.Companies.Queries.Handlers
{
    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<CompanyDto>>,
        IRequestHandler<GetCompanyByIdQuery, CompanyDto>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllCompaniesQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<Domain.Entities.Parties.Company>().ProjectTo<CompanyDto>(mapper.ConfigurationProvider));
        }

        public async Task<CompanyDto> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await dbContext.Query<Domain.Entities.Parties.Company>().FirstOrDefaultAsync(p => p.Id == request.Id);
            return mapper.Map<CompanyDto>(company);
        }
    }
}
