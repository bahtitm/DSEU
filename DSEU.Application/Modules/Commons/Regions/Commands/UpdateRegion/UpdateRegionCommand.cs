using DSEU.Domain.Entities;
using MediatR;

namespace DSEU.Application.Modules.Commons.Regions.Commands.UpdateRegion
{
    public class UpdateRegionCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionCode { get; set; }
        public Status Status { get; set; }
    }
}
