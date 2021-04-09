using AutoMapper;
using DSEU.Application.Modules.Company.OurOrganization.Agencies.Commands.CreateAgency;
using DSEU.Application.Modules.Company.OurOrganization.Agencies.Commands.UpdateAgency;
using DSEU.Application.Modules.Company.OurOrganization.Agencies.Dtos;
using DSEU.Domain.Entities.OurOrganization;

namespace DSEU.Application.Modules.Company.OurOrganization.Agencies.MappingProfile
{
    public class AgencyMappingProfile : Profile
    {
        public AgencyMappingProfile()
        {
            CreateMap<CreateAgencyCommand, Agency>();
            CreateMap<UpdateAgencyCommand, Agency>();

            CreateMap<Agency, AgencyDto>();
        }
    }
}
