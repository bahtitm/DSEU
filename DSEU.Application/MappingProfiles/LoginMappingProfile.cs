using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using DSEU.Application.Common.Mapping;
using DSEU.Application.Dtos.CoreEntities;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.MappingProfiles
{
    public class LoginMappingProfile : Profile
    {
        public LoginMappingProfile()
        {
            CreateMap<Login, LoginDto>();
        }
    }
}
