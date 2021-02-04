using MediatR;

namespace DSEU.Application.Modules.Company.DepartmentMembers.Commands.AddDepartmentMember
{
    public class AddDepartmentMemberCommand : IRequest
    {
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
    }
}
