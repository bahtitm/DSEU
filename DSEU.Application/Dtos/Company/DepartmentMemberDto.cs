namespace DSEU.Application.Dtos.Company
{
    public class DepartmentMemberDto
    {
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsReadonly { get; set; }
    }
}
