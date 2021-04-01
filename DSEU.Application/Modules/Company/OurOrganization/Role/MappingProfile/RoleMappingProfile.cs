using AutoMapper;
using DSEU.Application.Modules.Company.OurOrganization.Role.Dtos;
using Microsoft.AspNetCore.Identity;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.MappingProfile
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<IdentityRole, RoleDto>();
        }
    }
}
