using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
