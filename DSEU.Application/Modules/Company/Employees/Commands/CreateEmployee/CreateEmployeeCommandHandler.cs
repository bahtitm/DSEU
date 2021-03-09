using AutoMapper;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Persons;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.Employees.Commands.RegisterEmployee
{
    public class CreateEmployeeCommandHandler : AsyncRequestHandler<CreateEmployeeCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateEmployeeCommandHandler(IApplicationDbContext dbContext,IMapper mapper )
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = mapper.Map<Employee>(request);
            await dbContext.AddAsync(employee);
            await dbContext.SaveChangesAsync();
        }
    }
}
