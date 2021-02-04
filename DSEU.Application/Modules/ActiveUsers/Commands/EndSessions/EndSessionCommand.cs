using MediatR;

namespace DSEU.Application.Modules.ActiveUsers.Commands.EndSessions
{
    public class EndSessionCommand : IRequest
    {
        public string UserId { get; set; }
    }
}
