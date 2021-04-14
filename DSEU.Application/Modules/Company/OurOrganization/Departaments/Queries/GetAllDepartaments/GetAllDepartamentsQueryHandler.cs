using AutoMapper;
using AutoMapper.QueryableExtensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Company.OurOrganization.Departaments.Dtos;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Departaments.Queries.GetAllDepartaments
{
    public class GetAllDepartamentsQueryHandler : IRequestHandler<GetAllDepartamentsQuery, IEnumerable<DepartamentDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetAllDepartamentsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DepartamentDto>> Handle(GetAllDepartamentsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Department>().ProjectTo<DepartamentDto>(mapper.ConfigurationProvider));
        }
    }
}
