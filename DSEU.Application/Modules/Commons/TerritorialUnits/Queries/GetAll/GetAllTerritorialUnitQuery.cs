using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.Commons.TerritorialUnits.Queries.GetAll
{
    public class GetAllTerritorialUnitQuery : IRequest<IEnumerable<TerritorialUnitDto>>
    {

    }
}
