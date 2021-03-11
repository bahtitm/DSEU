using DSEU.Application.Modules.Company.OurOrganization.Dtos;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.Company.OurOrganization.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserDto>>
    {

    }
}
