using AutoMapper;
using DSEU.Application.Dtos;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.MappingProfiles
{
    public class EntityInfoMappingProfile : Profile
    {
        public EntityInfoMappingProfile()
        {
            CreateMap<User, EntityInfo>();
            CreateMap<Employee, EntityInfo>();
            CreateMap<SystemUser, EntityInfo>();
        }
    }
}
