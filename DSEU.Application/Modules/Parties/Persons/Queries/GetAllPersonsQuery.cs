using System.Collections.Generic;
using MediatR;
using DSEU.Application.Modules.Parties.Persons.Models;

namespace DSEU.Application.Modules.Parties.Persons.Queries
{
    public class GetAllPersonsQuery : IRequest<IEnumerable<PersonDto>>
    {
    }
}
