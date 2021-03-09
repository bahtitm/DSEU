using AutoMapper;
using DSEU.Application.Modules.Company.Employees.Commands.RegisterEmployee;
using DSEU.Domain.Entities.Persons;

namespace DSEU.Application.Modules.Company.Employees.MappingProfile
{
    public class EmployeeMappingProfile:Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<CreateEmployeeCommand, Employee>();
        }
    }
}
