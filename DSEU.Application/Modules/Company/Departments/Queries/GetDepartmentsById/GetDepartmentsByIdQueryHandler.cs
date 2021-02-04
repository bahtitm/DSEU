using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Dtos.Company;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.Departments.Queries.GetDepartmentsById
{
    public class GetDepartmentsByIdQueryHandler : IRequestHandler<GetDepartmentsByIdQuery, DepartmentDto>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDepartmentsByIdQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<DepartmentDto> Handle(GetDepartmentsByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await dbContext.Query<Department>().FirstOrDefaultAsync(d => d.Id == request.Id);

            return mapper.Map<DepartmentDto>(department);
        }
    }
}
