using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Dtos.CoreEntities
{
    public class LoginDto : DatabookEntryDto, IMapFrom<Login>
    {
        public string LoginName { get; set; }
    }
}
