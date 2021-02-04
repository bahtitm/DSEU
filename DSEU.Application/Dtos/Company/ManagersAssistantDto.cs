using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Dtos.Company
{
    public class ManagersAssistantDto : DatabookEntryDto, IMapFrom<ManagersAssistant>
    {
        public EmployeeDto Manager { get; set; }
        public EmployeeDto Assistant { get; set; }
        /// <summary>
        /// Готовит резолюцию для руководителя
        /// </summary>
        public bool PreparesResolution { get; set; }
    }
}
