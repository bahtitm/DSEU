using MediatR;

namespace DSEU.Application.Modules.Parties.Organizations.Contacts.Commands.RemoveContact
{
    public class RemoveContactCommand : IRequest
    {
        public RemoveContactCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
