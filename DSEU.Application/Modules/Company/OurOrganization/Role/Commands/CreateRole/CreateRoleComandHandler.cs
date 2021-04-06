using DSEU.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.CreateRole
{
    public class CreateRoleComandHandler : AsyncRequestHandler<CreateRoleCommand>
    {
        private readonly IRoleManager roleManager;
        public CreateRoleComandHandler(IRoleManager roleManager)
        {
            this.roleManager = roleManager;
        }

        protected override async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await roleManager.CreateRoleAsync(request.Name, request.UserClaimTypes);
        }
    }
}
