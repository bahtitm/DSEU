using DSEU.Domain.Entities;

namespace DSEU.Application.Dtos.AccessRights
{
    public class GrantAccessRightDto
    {
        public int RecipientId { get; set; }
        public int EntityId { get; set; }
        public int AccessRightTypeId { get; set; }
        public EntityTypeGuid EntityType { get; set; }
    }

}
