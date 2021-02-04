using MediatR;

namespace DSEU.Application.Modules.Permissions.Commands
{
    public class DeleteRecipientPermissionCommand : IRequest
    {
        public DeleteRecipientPermissionCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
