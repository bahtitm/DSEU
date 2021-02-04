using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Parties.Persons.Models;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, PersonDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreatePersonCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<PersonDto> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            Person person = mapper.Map<Person>(request);
            person.RecomputePersonName();
            await dbContext.AddAsync(person);
            await dbContext.SaveChangesAsync();
            return mapper.Map<PersonDto>(person);
        }
    }
}
