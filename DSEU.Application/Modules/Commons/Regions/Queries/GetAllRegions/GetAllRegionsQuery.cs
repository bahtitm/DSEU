using DSEU.Application.Modules.Commons.Regions.Dtos;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.Commons.Regions.Queries.GetAllRegions
{
    public class GetAllRegionsQuery : IRequest<IEnumerable<RegionDto>>
    {

    }
}
