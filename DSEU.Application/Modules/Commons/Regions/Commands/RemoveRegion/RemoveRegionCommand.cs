using MediatR;

namespace DSEU.Application.Modules.Commons.Regions.Commands.RemoveRegion
{
    public class RemoveRegionCommand : IRequest
    {
        public RemoveRegionCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
