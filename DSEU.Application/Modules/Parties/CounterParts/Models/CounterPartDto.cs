using DSEU.Application.Common.Mapping;
using DSEU.Application.Modules.Parties.Shared.Models;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.CounterParts.Models
{
    public class CounterPartDto : CounterPartBaseDto, IMapFrom<Counterparty>
    {
    }
}
