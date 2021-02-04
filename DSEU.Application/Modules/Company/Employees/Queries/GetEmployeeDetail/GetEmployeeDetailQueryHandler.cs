using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.MappingProfiles;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.Employees.Queries.GetEmployeeDetail
{
    public class GetEmployeeDetailQueryHandler : IRequestHandler<GetEmployeeDetailQuery, EmployeeDetailDto>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetEmployeeDetailQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<EmployeeDetailDto> Handle(GetEmployeeDetailQuery request, CancellationToken cancellationToken)
        {
            var employee = await dbContext.Query<Employee>()
                                          .Include(p => p.Login)
                                          .Include(p => p.Department)
                                          .FirstOrDefaultAsync(p => p.Id == request.Id);

            return mapper.Map<EmployeeDetailDto>(employee);
        }
    }
}
