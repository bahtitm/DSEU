using DSEU.Application.Modules.Company.OurOrganization.Agencies.Dtos;
using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Agencies.Queries.GetAgencyDetail
{
    public record GetAgencyDetailQuery(int id) : IRequest<AgencyDto>;
}
