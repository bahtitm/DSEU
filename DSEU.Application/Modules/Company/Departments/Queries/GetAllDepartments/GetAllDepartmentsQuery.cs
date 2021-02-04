using System.Collections.Generic;
using MediatR;
using DSEU.Application.Dtos.Company;

namespace DSEU.Application.Modules.Company.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQuery : IRequest<IEnumerable<DepartmentDto>>
    {
    }
}
