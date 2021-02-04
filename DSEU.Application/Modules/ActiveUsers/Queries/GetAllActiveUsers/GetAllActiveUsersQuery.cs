using MediatR;
using System.Collections.Generic;
using DSEU.Application.Dtos;

namespace DSEU.Application.Modules.ActiveUsers.Queries.GetAllActiveUsers
{
    public class GetAllActiveUsersQuery : IRequest<IEnumerable<ActiveUser>>
    {
    }
}