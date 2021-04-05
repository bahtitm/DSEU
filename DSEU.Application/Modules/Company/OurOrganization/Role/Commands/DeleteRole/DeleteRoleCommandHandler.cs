using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : AsyncRequestHandler<DeleteRoleCommand>
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public DeleteRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        protected override async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await roleManager.FindByIdAsync(request.Id);

            await roleManager.DeleteAsync(role);
        }
    }
}
