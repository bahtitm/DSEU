using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest
    {
        public string Id { get; set; }

        public DeleteRoleCommand(string id)
        {
            Id = id;
        }
    }
}
