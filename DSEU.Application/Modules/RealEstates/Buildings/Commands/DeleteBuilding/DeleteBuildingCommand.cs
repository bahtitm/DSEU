using MediatR;

namespace DSEU.Application.Modules.RealEstates.Buildings.Commands.DeleteBuilding
{
    public class DeleteBuildingCommand : IRequest
    {
        public DeleteBuildingCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
