using DSEU.Domain.Entities;
using MediatR;

namespace DSEU.Application.Modules.Commons.Regions.Commands.CreateRegion
{
    public class CreateRegionCommand : IRequest
    {
        public string Name { get; set; }
        public int RegionCode { get; set; }
        public Status Status { get; set; }
    }
}
