using MediatR;
using DSEU.Application.Modules.Parties.Organizations.Contacts.Models;

namespace DSEU.Application.Modules.Parties.Organizations.Contacts.Queries
{
    public class GetContactByIdQuery : IRequest<ContactDto>
    {
        public GetContactByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
