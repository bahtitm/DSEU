using DSEU.Application.Common.Mapping;
using DSEU.Application.Dtos.CoreEntities;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.MappingProfiles
{
    public class AccessRightsMapperProfile : MappingProfileBase
    {
        public AccessRightsMapperProfile()
        {
            CreateMap<AccessRightsType, AccessRightTypeDto>();
            CreateMap<Recipient, AccessRightEntryRecipientDto>();
        }
    }
}
