using AutoMapper;
using DSEU.Application.Modules.Company.OurOrganization.Departaments.Commands.CreateDepartament;
using DSEU.Application.Modules.Company.OurOrganization.Departaments.Commands.UpdateDepartament;
using DSEU.Application.Modules.Company.OurOrganization.Departaments.Dtos;
using DSEU.Domain.Entities.OurOrganization;

namespace DSEU.Application.Modules.Company.OurOrganization.Departaments.MappingProfile
{
    public class DepartamentMappingProfile : Profile
    {
        public DepartamentMappingProfile()
        {
            CreateMap<CreateDepartamentCommand, Departament>();
            CreateMap<UpdateDepartamentCommand, Departament>();

            CreateMap<Departament, DepartamentDto>();
        }
    }
}
