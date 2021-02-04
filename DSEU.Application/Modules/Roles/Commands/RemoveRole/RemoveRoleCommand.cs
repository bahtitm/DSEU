using MediatR;

namespace DSEU.Application.Modules.Roles.Commands.RemoveRole
{
    public class RemoveRoleCommand : IRequest
    {
        public RemoveRoleCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
