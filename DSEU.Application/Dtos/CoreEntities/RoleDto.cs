using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Dtos.CoreEntities
{
    public class RoleDto : RecipientBaseDto, IMapFrom<Role>
    {
        public bool Immutable { get; set; }
    }
}
