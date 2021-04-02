using DSEU.Application.Modules.Commons.Regions.Dtos;
using MediatR;

namespace DSEU.Application.Modules.Commons.Regions.Queries.GetRegionDetail
{
    public class GetRegionDetailQuery : IRequest<RegionDto>
    {
        public int Id { get; set; }

        public GetRegionDetailQuery(int id)
        {
            Id = id;
        }
    }
}
