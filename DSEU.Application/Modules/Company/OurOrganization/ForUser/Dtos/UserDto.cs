using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.OurOrganization;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.Dtos
{
    public class UserDto : IMapFrom<User>
    {
        public string Name { get; set; }
    }
}
