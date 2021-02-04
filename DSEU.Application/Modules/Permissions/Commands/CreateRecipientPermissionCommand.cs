using MediatR;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Modules.Permissions.Commands
{
    public class CreateRecipientPermissionCommand : IRequest
    {
        public int RecipientId { get; set; }
        public EntityTypeGuid EntityTypeGuid { get; set; }
        public AccessRightsOperation Operation { get; set; }
    }
}
