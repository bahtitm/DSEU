using DSEU.Application.Common.Enums;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserClaimTypes> UserClaimTypes { get; set; }
    }
}
