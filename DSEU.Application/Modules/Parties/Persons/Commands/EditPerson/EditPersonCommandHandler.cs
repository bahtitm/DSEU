using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Parties.Persons.Models;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Persons.Commands.EditPerson
{
    public class EditPersonCommandHandler : IRequestHandler<EditPersonCommand, PersonDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public EditPersonCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<PersonDto> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await dbContext.FindByIdAsync<Person>(request.Id, cancellationToken);
            mapper.Map(request, person);
            person.RecomputePersonName();
            await dbContext.SaveChangesAsync();
            return mapper.Map<PersonDto>(person);
        }
    }
}
