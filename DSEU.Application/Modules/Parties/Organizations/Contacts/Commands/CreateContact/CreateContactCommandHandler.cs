using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Parties.Organizations.Contacts.Models;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Contacts.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ContactDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateContactCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ContactDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = mapper.Map<Contact>(request);
            await dbContext.AddAsync(contact, cancellationToken);
            await dbContext.SaveChangesAsync();
            return mapper.Map<ContactDto>(contact);
        }
    }
}
