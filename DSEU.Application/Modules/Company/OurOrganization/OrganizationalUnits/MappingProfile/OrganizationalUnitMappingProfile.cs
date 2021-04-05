using AutoMapper;
using DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Commands.CreateOrganizationalUnit;
using DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Commands.UpdateOrganizationalUnit;
using DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Dtos;
using DSEU.Domain.Entities.OurOrganization;

namespace DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.MappingProfile
{
    public class OrganizationalUnitMappingProfile : Profile
    {
        public OrganizationalUnitMappingProfile()
        {
            CreateMap<CreateOrganizationalUnitCommand, OrganizationalUnit>();
            CreateMap<UpdateOrganizationalUnitCommand, OrganizationalUnit>();

            CreateMap<OrganizationalUnit, OrganizationalUnitDto>();
        }
    }
}
