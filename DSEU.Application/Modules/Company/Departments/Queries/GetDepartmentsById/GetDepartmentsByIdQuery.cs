using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using DSEU.Application.Dtos.Company;

namespace DSEU.Application.Modules.Company.Departments.Queries.GetDepartmentsById
{
    public class GetDepartmentsByIdQuery : IRequest<DepartmentDto>
    {
        public GetDepartmentsByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
