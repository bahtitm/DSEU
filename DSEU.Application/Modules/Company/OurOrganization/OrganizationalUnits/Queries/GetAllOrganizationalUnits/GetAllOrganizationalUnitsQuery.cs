using DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Dtos;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Queries.GetAllOrganizationalUnits
{
    public class GetAllOrganizationalUnitsQuery : IRequest<IEnumerable<OrganizationalUnitDto>>
    {

    }
}
