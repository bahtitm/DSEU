using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Contacts.Commands.RemoveContact
{
    public class RemoveContactCommandHandler : AsyncRequestHandler<RemoveContactCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public RemoveContactCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await dbContext.FindByIdAsync<Contact>(request.Id);
            dbContext.Set<Contact>().Remove(contact);
            await dbContext.SaveChangesAsync();
        }
    }
}
