using DSEU.Application.Modules.Company.OurOrganization.Role.Dtos;
using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Queries.GetRoleDetail
{
    public class GetRoleDetailQuery : IRequest<RoleDetailDto>
    {
        public string Id { get; set; }

        public GetRoleDetailQuery(string id)
        {
            Id = id;
        }
    }
}
