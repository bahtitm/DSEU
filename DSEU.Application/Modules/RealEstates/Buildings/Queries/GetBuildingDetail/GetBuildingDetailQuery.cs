using DSEU.Application.Modules.RealEstates.Buildings.Dtos;
using MediatR;

namespace DSEU.Application.Modules.RealEstates.Buildings.Queries.GetBuildingDetail
{
    public class GetBuildingDetailQuery : IRequest<BuildingDto>
    {
        public GetBuildingDetailQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
