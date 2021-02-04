using System.Collections.Generic;
using MediatR;
using DSEU.Application.Dtos.Company;

namespace DSEU.Application.Modules.Company.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDto>>
    {
    }
}
