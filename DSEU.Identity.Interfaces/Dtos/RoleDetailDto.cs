using System.Collections.Generic;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Dtos
{
    public class RoleDetailDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}
