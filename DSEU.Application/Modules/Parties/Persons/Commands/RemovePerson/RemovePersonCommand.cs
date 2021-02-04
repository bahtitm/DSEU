using MediatR;

namespace DSEU.Application.Modules.Parties.Persons.Commands.RemovePerson
{
    public class RemovePersonCommand : IRequest
    {
        public int Id { get; set; }
    }
}
