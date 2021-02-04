using AutoMapper;
using DSEU.Application.Modules.Company.Departments.Commands.CreateDepartment;
using DSEU.Application.Modules.Company.Departments.Commands.EditDepartment;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.MappingProfiles
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<EditDepartmentCommand, Department>();
            CreateMap<CreateDepartmentCommand, Department>();
        }
    }
}
