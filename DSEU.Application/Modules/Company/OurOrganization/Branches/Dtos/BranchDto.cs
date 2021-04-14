using DSEU.Application.Dtos;

namespace DSEU.Application.Modules.Company.OurOrganization.Branches.Dtos
{
    public class BranchDto : DatabookEntryDto
    {
        public int DepartamentId { get; set; }
        public int DistrictId { get; set; }
    }
}
