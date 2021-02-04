using AutoMapper;
using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Dtos
{
    public class RecipientPermissionDto : IMapFrom<AccessRightEntry>
    {
        public int Id { get; set; }
        public int RecipientId { get; set; }
        public EntityTypeGuid EntityTypeGuid { get; set; }
        public AccessRightsOperation Operation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AccessRightEntry, RecipientPermissionDto>()
                .ForMember(p => p.EntityTypeGuid, k => k.MapFrom(p => p.AccessRightsType.EntityTypeGuid))
                .ForMember(p => p.Operation, k => k.MapFrom(p => p.AccessRightsType.Operation));
        }
    }
}
