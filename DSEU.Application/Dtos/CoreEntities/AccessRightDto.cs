using System.Collections.Generic;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.Content;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Extensions;

namespace DSEU.Application.Dtos.CoreEntities
{
    public class AccessRightEntity
    {
        public AccessRightEntity(int entityId, EntityTypeGuid entityTypeGuid)
        {
            EntityId = entityId;
            EntityTypeGuid = entityTypeGuid;
        }
       
        public int EntityId { get; }
        public EntityTypeGuid EntityTypeGuid { get; }
    }

    public class AccessRightTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AccessRightsOperation Operation { get; set; }
    }

    public class AccessRightDto
    {
        public IEnumerable<AccessRightTypeDto> AccessRightTypes { get; set; }
        public IEnumerable<AccessRightEntryDto> Entries { get; set; }
    }

    public class AccessRightEntityOperation
    {
        public AccessRightEntity Entity { get; set; }
        public AccessRightsOperation Operation { get; set; }
    }

    public class AccessRightEntryDto
    {
        public int Id { get; set; }
        public AccessRightEntryRecipientDto Recipient { get; set; }
        public AccessRightTypeDto AccessRightType { get; set; }
        public bool CanRemove { get; set; }
        public bool CanUpdate { get; set; }
    }

    public class AccessRightEntryRecipientDto : RecipientBaseDto
    {

    }

}
