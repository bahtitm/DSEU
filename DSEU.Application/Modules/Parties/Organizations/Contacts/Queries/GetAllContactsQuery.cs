using System.Collections.Generic;
using MediatR;
using DSEU.Application.Modules.Parties.Organizations.Contacts.Models;

namespace DSEU.Application.Modules.Parties.Organizations.Contacts.Queries
{
    public class GetAllContactsQuery : IRequest<IEnumerable<ContactDto>>
    {

    }
}
