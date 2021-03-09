using DSEU.Application.Modules.RealEstates.Lands.Dtos;
using MediatR;

namespace DSEU.Application.Modules.RealEstates.Lands.Queries.GetLandDetail
{
    public class GetLandDetailQuery : IRequest<LandDto>
    {
        public GetLandDetailQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
