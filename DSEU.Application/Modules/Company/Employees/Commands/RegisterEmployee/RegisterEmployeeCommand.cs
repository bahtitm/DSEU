using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }


    }
}
