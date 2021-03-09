using DSEU.Application.Modules.RealEstates.Lands.Dtos;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.RealEstates.Lands.Queries.GetAllLands
{
    public class GetAllLandsQuery : IRequest<IEnumerable<LandDto>>
    {

    }
}
