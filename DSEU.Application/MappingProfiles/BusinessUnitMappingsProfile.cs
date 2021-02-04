using AutoMapper;
using DSEU.Application.Modules.Company.BusinessUnits.Commands.CreateBusinessUnit;
using DSEU.Application.Modules.Company.BusinessUnits.Commands.EditBusinessUnit;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.MappingProfiles
{
    public class BusinessUnitMappingsProfile : Profile
    {
        public BusinessUnitMappingsProfile()
        {
            CreateMap<CreateBusinessUnitCommand, BusinessUnit>();
            CreateMap<EditBusinessUnitCommand, BusinessUnit>();

            CreateMap<BusinessUnit, Domain.Entities.Parties.Company>()
                .ForMember(p => p.PostAddress, p => p.MapFrom(p => p.PostalAddress))
                .ForMember(p => p.WebSite, p => p.MapFrom(p => p.Homepage))
                .ForMember(p => p.Note, p => p.Ignore())
                .ForMember(p => p.HeadCompany, p => p.Ignore())
                .ForMember(p => p.HeadCompanyId, p => p.Ignore())
                .ForMember(p => p.Id, p => p.Ignore());
        }
    }
}
