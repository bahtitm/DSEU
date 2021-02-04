using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Parties.Persons.Models;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Persons.Queries.Handlers
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<PersonDto>>,
        IRequestHandler<GetPersonByIdQuery, PersonDto>
    {
        private readonly IReadOnlyApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllPersonsQueryHandler(IReadOnlyApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PersonDto>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Query<Person>().ProjectTo<PersonDto>(mapper.ConfigurationProvider));
        }

        public async Task<PersonDto> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var person = await dbContext.Query<Person>().FirstOrDefaultAsync(p => p.Id == request.Id);
            return mapper.Map<PersonDto>(person);
        }
    }
}
