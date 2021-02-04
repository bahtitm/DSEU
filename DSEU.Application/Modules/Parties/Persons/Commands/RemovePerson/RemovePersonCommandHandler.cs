using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Extensions;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Persons.Commands.RemovePerson
{
    public class RemovePersonCommandHandler : AsyncRequestHandler<RemovePersonCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public RemovePersonCommandHandler(
            IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(RemovePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await dbContext.FindByIdAsync<Person>(request.Id, cancellationToken); 
            dbContext.Set<Person>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }


    }
}
