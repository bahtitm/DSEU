using System.Collections.Generic;

namespace DSEU.Application.Modules.Company.OurOrganization.Role.Dtos
{
    public class RoleDetailDto
    {
        public string Name { get; set; }
        public List<string> Claims { get; set; } = new List<string>();
    }
}
