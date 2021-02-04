using AutoMapper;
using DSEU.Application.Modules.Parties.Organizations.Companies.Commands.CreateComany;
using DSEU.Application.Modules.Parties.Organizations.Companies.Commands.EditComany;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.MappingProfiles
{
    public class CompaniesMappingProfile : Profile
    {
        public CompaniesMappingProfile()
        {
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<EditCompanyCommand, Company>();
        }
    }
}
