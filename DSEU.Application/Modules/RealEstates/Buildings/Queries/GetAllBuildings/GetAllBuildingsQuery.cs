using DSEU.Application.Modules.RealEstates.Buildings.Dtos;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.RealEstates.Buildings.Queries.GetAllBuildings
{
    public class GetAllBuildingsQuery : IRequest<IEnumerable<BuildingDto>>
    {

    }
}
