using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using DSEU.Application.Dtos.CoreEntities;

namespace DSEU.Application.Modules.CoreEntities.Logins.Queries
{
    public class GetAllLoginsQuery : IRequest<IEnumerable<LoginDto>>
    {
    }
}
