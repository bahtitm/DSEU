using AutoMapper;
using DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.CreateUser;
using DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.UpdateUser;
using DSEU.Application.Modules.Company.OurOrganization.ForUser.Dtos;
using DSEU.Domain.Entities.OurOrganization;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserComand, User>();
            
            CreateMap<User, UserDto>();
        }
    }
}
