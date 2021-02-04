using System.Collections.Generic;
using MediatR;
using DSEU.Application.Dtos;

namespace DSEU.Application.Modules.Permissions.Queries.GetRecipientPermissions
{
    public class GetRecipientPermissionsQuery : IRequest<IEnumerable<RecipientPermissionDto>>
    {
        public GetRecipientPermissionsQuery(int recipientId)
        {
            RecipientId = recipientId;
        }

        public int RecipientId { get; }
    }

}
