using System.Collections.Generic;
using MediatR;
using DSEU.Application.Modules.Parties.Organizations.Banks.Models;

namespace DSEU.Application.Modules.Parties.Organizations.Banks.Queries
{
    public class GetAllBanksQuery : IRequest<IEnumerable<BankDto>>
    {
    }

}
