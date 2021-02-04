using System.Collections.Generic;
using MediatR;
using DSEU.Application.Dtos.Commons;

namespace DSEU.Application.Modules.Commons.Regions.Queries.GetAllRegions
{
    public class GetAllRegionsQuery : IRequest<IEnumerable<RegionDto>>
    {
    }
}
