using DSEU.Application.Modules.Company.OurOrganization.Dtos;
using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<UserDto>
    {
        public int id;

        public GetUserDetailQuery(int Id)
        {
            id = Id;
        }
    }
}
