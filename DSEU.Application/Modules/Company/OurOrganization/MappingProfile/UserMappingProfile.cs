using AutoMapper;
using DSEU.Application.Modules.Company.OurOrganization.Commands.CreateUser;
using DSEU.Application.Modules.Company.OurOrganization.Commands.UpdateUser;
using DSEU.Application.Modules.Company.OurOrganization.Dtos;
using DSEU.Domain.Entities.OurOrganization;

namespace DSEU.Application.Modules.Company.OurOrganization.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            //for comands
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserComand, User>();
            //for queri
            CreateMap<User, UserDto>();
        }
    }
}
