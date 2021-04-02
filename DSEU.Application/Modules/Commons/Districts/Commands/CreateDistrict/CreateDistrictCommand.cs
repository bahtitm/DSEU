using DSEU.Domain.Entities;
using MediatR;

namespace DSEU.Application.Modules.Commons.Districts.Commands.CreateDistrict
{
    public class CreateDistrictCommand : IRequest
    {
        public string Name { get; set; }
        public int DistrictCode { get; set; }
        public int RegionId { get; set; }
        public Status Status { get; set; }
    }
}
