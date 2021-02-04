using AutoMapper;
using DSEU.Application.Modules.Company.Employees.Commands.EditEmployee;
using DSEU.Application.Modules.Company.Employees.Commands.RegisterEmployee;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<RegisterEmployeeCommand, Employee>()
                .ForMember(p => p.PersonalPhoto, p => p.Ignore());

            CreateMap<EditEmployeeCommand, Employee>()
                .ForMember(p => p.PersonalPhoto, p => p.Ignore());
        }
    }
}
