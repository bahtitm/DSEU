using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Agencies.Commands.DeleteAgency
{
    public record DeleteAgencyCommand(int id) : IRequest;
}
