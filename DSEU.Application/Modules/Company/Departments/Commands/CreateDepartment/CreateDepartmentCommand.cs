using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Company.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Уникальный код подразделения в организации
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Краткое наименование
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Id Головного подразделения
        /// </summary>
        public int? HeadOfficeId { get; set; }
        /// <summary>
        /// Id Организации
        /// </summary>
        public int BusinessUnitId { get; set; }
        /// <summary>
        /// Id руководителя подразделения
        /// </summary>
        public int? ManagerId { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public Status Status { get; set; }
    }
}
