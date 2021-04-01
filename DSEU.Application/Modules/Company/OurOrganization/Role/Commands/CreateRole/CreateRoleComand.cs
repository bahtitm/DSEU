using DSEU.Application.Common.Enums;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest
    {
        public string Name { get; set; }
        public IEnumerable<UserClaimTypes> UserClaimTypes { get; set; }
    }
}
