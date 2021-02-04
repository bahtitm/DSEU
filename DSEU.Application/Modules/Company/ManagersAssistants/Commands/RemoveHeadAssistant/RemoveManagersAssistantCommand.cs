using MediatR;

namespace DSEU.Application.Modules.Company.ManagersAssistants.Commands.RemoveHeadAssistant
{
    public class RemoveManagersAssistantCommand : IRequest
    {
        public int Id { get; set; }
    }
}
