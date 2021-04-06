using DSEU.Application.Common.Interfaces;
using DSEU.Application.Modules.Company.OurOrganization.Role.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Queries.GetRoleDetail
{
    public class GetRoleDetailQueryHandler : IRequestHandler<GetRoleDetailQuery, RoleDetailDto>
    {
        private readonly IRoleManager roleManager;

        public GetRoleDetailQueryHandler(IRoleManager roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<RoleDetailDto> Handle(GetRoleDetailQuery request, CancellationToken cancellationToken)
        {
            return await roleManager.GetRoleById(request.Id);
        }
    }
}
