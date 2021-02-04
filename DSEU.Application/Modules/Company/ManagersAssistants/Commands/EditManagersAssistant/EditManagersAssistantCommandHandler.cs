using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using DSEU.Application.Common.Interfaces;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Modules.Company.ManagersAssistants.Commands.EditManagersAssistant
{
    public class EditManagersAssistantCommandHandler : AsyncRequestHandler<EditManagersAssistantCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public EditManagersAssistantCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(EditManagersAssistantCommand request, CancellationToken cancellationToken)
        {
            var assistant = await dbContext.Set<ManagersAssistant>().FindAsync(request.Id);
            mapper.Map(request, assistant);
            await dbContext.SaveChangesAsync();
        }
    }

}
