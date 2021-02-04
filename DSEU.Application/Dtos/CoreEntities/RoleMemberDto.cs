using AutoMapper;
using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Dtos.CoreEntities
{
    public class RoleMemberDto : IMapFrom<RoleRecipientLinks>
    {
        public int RoleId { get; set; }
        public int MemberId { get; set; }
        public RecipientDto Member { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RoleRecipientLinks, RoleMemberDto>()
                .ForMember(p => p.MemberId, p => p.MapFrom(p => p.MemberId))
                .ForMember(p => p.RoleId, p => p.MapFrom(p => p.GroupId));
        }
    }
}
