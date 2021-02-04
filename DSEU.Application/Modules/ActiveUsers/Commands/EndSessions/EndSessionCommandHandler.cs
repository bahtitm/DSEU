using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DSEU.Application.Common.Interfaces;

namespace DSEU.Application.Modules.ActiveUsers.Commands.EndSessions
{
    public class EndSessionCommandHandler : AsyncRequestHandler<EndSessionCommand>
    {
        private readonly IActiveUserManager activeUserManager;

        public EndSessionCommandHandler(IActiveUserManager activeUserManager)
        {
            this.activeUserManager = activeUserManager;
        }

        protected async override Task Handle(EndSessionCommand request, CancellationToken cancellationToken)
        {
            await activeUserManager.EndSession(request.UserId);
        }
    }
}
