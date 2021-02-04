using MediatR;
using DSEU.Application.Dtos.Company;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Company.ManagersAssistants.Commands.EditManagersAssistant
{
    public class EditManagersAssistantCommand : IRequest
    {
        public int Id { get; set; }
        public EmployeeDto Manager { get; set; }
        public EmployeeDto Assistant { get; set; }
        /// <summary>
        /// Готовит резолюцию для руководителя
        /// </summary>
        public bool PreparesResolution { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
