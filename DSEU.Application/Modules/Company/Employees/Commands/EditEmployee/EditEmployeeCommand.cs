using MediatR;
using Microsoft.AspNetCore.Http;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Company.Employees.Commands.EditEmployee
{
    public class EditEmployeeCommand : IRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int JobTitleId { get; set; }
        public int DepartmentId { get; set; }
        public Status Status { get; set; }
        public string Note { get; set; }
        public IFormFile PersonalPhoto { get; set; }
    }
}
