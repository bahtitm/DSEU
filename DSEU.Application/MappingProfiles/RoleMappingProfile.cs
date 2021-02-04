using AutoMapper;
using DSEU.Application.Modules.Roles.Commands.CreateRole;
using DSEU.Application.Modules.Roles.Commands.UpdateRole;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.MappingProfiles
{
    public sealed class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<CreateRoleCommand, Role>();
            CreateMap<UpdateRoleCommand, Role>();
        }
    }
}
