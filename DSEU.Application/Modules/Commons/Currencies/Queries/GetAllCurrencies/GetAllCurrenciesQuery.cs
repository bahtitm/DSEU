using System.Collections.Generic;
using MediatR;
using DSEU.Application.Dtos.Commons;

namespace DSEU.Application.Modules.Commons.Currencies.Queries.GetAllCurrencies
{
    public class GetAllCurrenciesQuery : IRequest<IEnumerable<CurrencyDto>>
    {
    }


}
