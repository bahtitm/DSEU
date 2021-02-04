using MediatR;
using DSEU.Application.Modules.Parties.Organizations.Banks.Models;

namespace DSEU.Application.Modules.Parties.Organizations.Banks.Queries
{
    public class GetBankByIdQuery : IRequest<BankDto>
    {
        public GetBankByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
