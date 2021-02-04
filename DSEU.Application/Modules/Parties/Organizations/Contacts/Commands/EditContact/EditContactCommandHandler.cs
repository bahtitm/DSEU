using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Parties.Organizations.Contacts.Models;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Contacts.Commands.EditContact
{
    public class EditContactCommandHandler : IRequestHandler<EditContactCommand, ContactDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public EditContactCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ContactDto> Handle(EditContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await dbContext.FindByIdAsync<Contact>(request.Id, cancellationToken);
            mapper.Map(request, contact);
            await dbContext.SaveChangesAsync();
            return mapper.Map<ContactDto>(contact);
        }
    }
}
