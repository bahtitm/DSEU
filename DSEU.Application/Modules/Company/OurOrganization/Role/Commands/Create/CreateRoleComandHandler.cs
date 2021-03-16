using DSEU.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.Create
{
    public class CreateRoleComandHandler : IRequestHandler<CreateComand>
    {
        private readonly IIdentityService identtityService;

        public CreateRoleComandHandler(IIdentityService identtityService)
        {
            this.identtityService = identtityService;
        }

        public Task<Unit> Handle(CreateComand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
