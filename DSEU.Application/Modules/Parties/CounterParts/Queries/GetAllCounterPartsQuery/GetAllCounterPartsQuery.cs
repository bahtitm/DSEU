using System.Collections.Generic;
using MediatR;
using DSEU.Application.Modules.Parties.CounterParts.Models;

namespace DSEU.Application.Modules.Parties.CounterParts.Queries.GetAllCounterPartsQuery
{
    public class GetAllCounterPartsQuery : IRequest<IEnumerable<CounterPartDto>>
    {
    }

}
