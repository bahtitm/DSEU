using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using DSEU.Application.Dtos.CoreEntities;

namespace DSEU.Application.Modules.CoreEntities.Logins.Queries
{
    public class GetLoginsByIdQuery : IRequest<LoginDto>
    {
        public GetLoginsByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
