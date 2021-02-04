using MediatR;

namespace DSEU.Application.Modules.Company.Departments.Commands.RemoveDepartment
{
    public class RemoveDepartmentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
