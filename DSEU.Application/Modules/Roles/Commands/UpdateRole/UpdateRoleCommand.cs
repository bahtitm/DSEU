using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
