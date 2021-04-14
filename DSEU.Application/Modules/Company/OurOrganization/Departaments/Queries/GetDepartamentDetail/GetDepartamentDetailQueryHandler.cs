using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Company.OurOrganization.Departaments.Dtos;
using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Departaments.Queries.GetDepartamentDetail
{
    public class GetDepartamentDetailQueryHandler : IRequestHandler<GetDepartamentDetailQuery, DepartamentDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetDepartamentDetailQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<DepartamentDto> Handle(GetDepartamentDetailQuery request, CancellationToken cancellationToken)
        {
            var departament = await dbContext.Set<Department>().FirstOrDefaultAsync(p => p.Id == request.id);
            return mapper.Map<DepartamentDto>(departament);
        }
    }
}
