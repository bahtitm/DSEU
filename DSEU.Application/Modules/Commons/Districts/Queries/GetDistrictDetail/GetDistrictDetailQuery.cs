using DSEU.Application.Modules.Commons.Districts.Dtos;
using MediatR;

namespace DSEU.Application.Modules.Commons.Districts.Queries.GetDistrictDetail
{
    public class GetDistrictDetailQuery : IRequest<DistrictDto>
    {
        public int Id { get; set; }

        public GetDistrictDetailQuery(int id)
        {
            Id = id;
        }
    }
}
