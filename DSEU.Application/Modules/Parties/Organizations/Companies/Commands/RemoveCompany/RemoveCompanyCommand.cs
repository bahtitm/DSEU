using MediatR;

namespace DSEU.Application.Modules.Parties.Organizations.Companies.Commands.RemoveCompany
{
    public class RemoveCompanyCommand : IRequest
    {
        public int Id { get; set; }
    }
}
