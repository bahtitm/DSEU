using MediatR;
using DSEU.Application.Modules.Parties.Organizations.Companies.Models;
using DSEU.Application.Modules.Parties.Shared.Commands;

namespace DSEU.Application.Modules.Parties.Organizations.Companies.Commands.CreateComany
{


    public class CreateCompanyCommand : BaseCreateCounterPartCommand, IRequest<CompanyDto>
    {
        public string LegalName { get; set; }
        public string Account { get; set; }
        public int? BankId { get; set; }
        public int? HeadCompanyId { get; set; }

    }
}
