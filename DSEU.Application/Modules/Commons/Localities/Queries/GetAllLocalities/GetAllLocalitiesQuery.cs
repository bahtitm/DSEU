using System.Collections.Generic;
using MediatR;
using DSEU.Application.Dtos.Commons;

namespace DSEU.Application.Modules.Commons.Localities.Queries.GetAllLocalities
{
    public class GetAllLocalitiesQuery : IRequest<IEnumerable<LocalityDto>>
    {
    }
}
