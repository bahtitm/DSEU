using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.ManagersAssistants.Commands.CreateManagersAssistant
{
    public class CreateManagersAssistantCommandHandler : AsyncRequestHandler<CreateManagersAssistantCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateManagersAssistantCommandHandler(IApplicationDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        protected override async Task Handle(CreateManagersAssistantCommand request, CancellationToken cancellationToken)
        {
            ManagersAssistant ManagersAssistant = mapper.Map<ManagersAssistant>(request);
            await dbContext.AddAsync(ManagersAssistant);
            await dbContext.SaveChangesAsync();
        }
    }

}
