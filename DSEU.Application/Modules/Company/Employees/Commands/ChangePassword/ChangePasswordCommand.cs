using MediatR;

namespace DSEU.Application.Modules.Company.Employees.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest
    {
        /// <summary>
        /// ID сотрудника
        /// </summary>
        public int Id { get; set; }
        public string NewPassword { get; set; }
    }
}
