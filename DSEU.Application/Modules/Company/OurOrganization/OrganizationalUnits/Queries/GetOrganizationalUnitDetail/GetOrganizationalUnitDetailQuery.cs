using DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Dtos;
using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Queries.GetOrganizationalUnitDetail
{
    public class GetOrganizationalUnitDetailQuery : IRequest<OrganizationalUnitDto>
    {
        public int Id { get; set; }

        public GetOrganizationalUnitDetailQuery(int id)
        {
            Id = id;
        }
    }
}
