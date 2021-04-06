using DSEU.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : AsyncRequestHandler<DeleteRoleCommand>
    {
        private readonly IRoleManager roleManager;

        public DeleteRoleCommandHandler(IRoleManager roleManager)
        {
            this.roleManager = roleManager;
        }

        protected override async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await roleManager.DeleteRoleAsync(request.Id);
        }
    }
}
