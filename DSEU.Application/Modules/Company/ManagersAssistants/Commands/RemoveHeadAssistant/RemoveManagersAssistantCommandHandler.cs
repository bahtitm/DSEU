using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.ManagersAssistants.Commands.RemoveHeadAssistant
{

    public class RemoveManagersAssistantCommandHandler : AsyncRequestHandler<RemoveManagersAssistantCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public RemoveManagersAssistantCommandHandler(
            IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(RemoveManagersAssistantCommand request, CancellationToken cancellationToken)
        {
            var assistant = await dbContext.Set<ManagersAssistant>().FindAsync(request.Id);
            dbContext.Set<ManagersAssistant>().Remove(assistant);
            await dbContext.SaveChangesAsync();
        }


    }
}
