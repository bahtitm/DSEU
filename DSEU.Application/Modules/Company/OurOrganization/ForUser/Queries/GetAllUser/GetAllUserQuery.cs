using DSEU.Application.Modules.Company.OurOrganization.ForUser.Dtos;
using MediatR;
using System.Collections.Generic;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserDto>>
    {

    }
}
