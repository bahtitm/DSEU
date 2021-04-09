using DSEU.Application.Modules.Company.OurOrganization.Agencies.Dtos;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.Company.OurOrganization.Agencies.Queries.GetAgencyDetail
{
    public record GetAllAgenciesQuery : IRequest<IEnumerable<AgencyDto>>;
}
