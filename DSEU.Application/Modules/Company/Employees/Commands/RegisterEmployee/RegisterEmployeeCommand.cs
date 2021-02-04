using MediatR;
using Microsoft.AspNetCore.Http;

namespace DSEU.Application.Modules.Company.Employees.Commands.RegisterEmployee
{
    public class RegisterEmployeeCommand : IRequest
    {
        public RegisterEmployeeCommand(bool needChangePassword)
        {
            NeedChangePassword = needChangePassword;
        }
        public RegisterEmployeeCommand()
        {

        }
        public bool NeedChangePassword { get; private set; } = true;
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int JobTitleId { get; set; }
        public int DepartmentId { get; set; }
        public string Note { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public IFormFile PersonalPhoto { get; set; }
    }
}
