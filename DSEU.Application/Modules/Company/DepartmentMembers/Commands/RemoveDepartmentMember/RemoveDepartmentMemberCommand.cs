using MediatR;

namespace DSEU.Application.Modules.Company.DepartmentMembers.Commands.RemoveDepartmentMember
{
    public class RemoveDepartmentMemberCommand : IRequest
    {
        public RemoveDepartmentMemberCommand(int departmentId,int employeeId)
        {
            DepartmentId = departmentId;
            EmployeeId = employeeId;
        }
        public int DepartmentId { get; }
        public int EmployeeId { get; }
    }
}
