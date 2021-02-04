using MediatR;
using DSEU.Application.Dtos.Company;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Company.ManagersAssistants.Commands.CreateManagersAssistant
{
    public class CreateManagersAssistantCommand : IRequest
    {
        public EmployeeDto Manager { get; set; }
        public EmployeeDto Assistant { get; set; }
        /// <summary>
        /// ������� ��������� ��� ������������
        /// </summary>
        public bool PreparesResolution { get; set; }
        /// <summary>
        /// ���������
        /// </summary>
        public Status Status { get; set; }
    }
}
