using MediatR;
using DSEU.Application.Modules.Parties.Persons.Models;

namespace DSEU.Application.Modules.Parties.Persons.Queries
{
    public class GetPersonByIdQuery : IRequest<PersonDto>
    {
        public int Id { get; }
        public GetPersonByIdQuery(int id)
        {
            Id = id;
        }
    }
}
