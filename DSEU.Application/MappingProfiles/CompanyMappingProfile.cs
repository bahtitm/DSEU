using DSEU.Application.Common.Mapping;
using DSEU.Application.Dtos;
using DSEU.Application.Dtos.Company;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.MappingProfiles
{
    public sealed class CompanyMappingProfile : MappingProfileBase
    {
        public CompanyMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dp => dp.BusinessUnitId, sp => sp.MapFrom(sp => sp.Department.BusinessUnitId))
                .ForMember(dp => dp.UserName, sp => sp.MapFrom(sp => sp.Login.LoginName))
                .ForMember(dp => dp.JobTitle, sp => sp.MapFrom(sp => sp.Description))
                .ForMember(p => p.PersonalPhoto, p => p.Ignore());

            CreateMap<Recipient, RecipientEntityInfo>();
            CreateMap<User, UserDto>();

            CreateMap<User, UserEntityInfo>()
                .IncludeBase<Recipient, RecipientEntityInfo>();

            CreateMap<Employee, RecipientEntityInfo>()
                .IncludeBase<Recipient, RecipientEntityInfo>();

            CreateMap<Employee, RecipientEntityInfo>()
                .IncludeBase<Recipient, RecipientEntityInfo>();
        }
    }
}
