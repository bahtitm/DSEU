using MediatR;
using DSEU.Application.Modules.Parties.Organizations.Banks.Models;
using DSEU.Application.Modules.Parties.Shared.Commands;

namespace DSEU.Application.Modules.Parties.Organizations.Banks.Commands.CreateBank
{
    public class CreateBankCommand : BaseCreateCounterPartCommand, IRequest<BankDto>
    {
        public string LegalName { get; set; }
        public string BIC { get; set; }
        public string CorrespondentAccount { get; set; }
    }
}
