using MediatR;

namespace DSEU.Application.Modules.Commons.Localities.Commands.RemoveLocality
{
    public class RemoveLocalityCommand : IRequest
    {
        public RemoveLocalityCommand(int id)
        {
            Id = id;
        }

        public int Id { get;}
    }
}
