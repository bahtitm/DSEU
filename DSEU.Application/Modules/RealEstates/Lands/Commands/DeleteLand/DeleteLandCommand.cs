using MediatR;

namespace DSEU.Application.Modules.RealEstates.Lands.Commands.DeleteLand
{
    public class DeleteLandCommand : IRequest
    {
        public DeleteLandCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
