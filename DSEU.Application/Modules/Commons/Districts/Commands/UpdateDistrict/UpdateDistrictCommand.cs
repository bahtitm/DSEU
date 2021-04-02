using DSEU.Domain.Entities;
using MediatR;

namespace DSEU.Application.Modules.Commons.Districts.Commands.UpdateDistrict
{
    public class UpdateDistrictCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictCode { get; set; }
        public int RegionId { get; set; }
        public Status Status { get; set; }
    }
}
