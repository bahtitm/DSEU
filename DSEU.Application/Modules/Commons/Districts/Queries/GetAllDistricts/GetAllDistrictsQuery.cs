using DSEU.Application.Modules.Commons.Districts.Dtos;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.Commons.Districts.Queries.GetAllDistricts
{
    public class GetAllDistrictsQuery : IRequest<IEnumerable<DistrictDto>>
    {

    }
}
