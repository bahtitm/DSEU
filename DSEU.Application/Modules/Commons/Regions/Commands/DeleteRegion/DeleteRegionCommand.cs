using MediatR;

namespace DSEU.Application.Modules.Commons.Regions.Commands.DeleteRegion
{
    public class DeleteRegionCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteRegionCommand(int id)
        {
            Id = id;
        }
    }
}
