using DSEU.Domain.Entities.OurOrganization;
using MediatR;
using System;

namespace DSEU.Application.Modules.Company.Employees.Commands.RegisterEmployee
{
    public class CreateEmployeeCommand : IRequest
    {
        public CreateEmployeeCommand(bool needChangePassword)
        {
            NeedChangePassword = needChangePassword;
        }

        public CreateEmployeeCommand()
        {

        }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Sex Sex { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Рабочий телефон
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Дата приема
        /// </summary>
        public DateTime? DateOfAppointment { get; set; }
        /// <summary>
        /// Дата увольнения
        /// </summary>
        public DateTime? DateOfDismissal { get; set; }
        /// <summary>
        /// ID организационной единицы
        /// </summary>
        public int? OrganizationalUnitId { get; set; }
        /// <summary>
        /// ID должности
        /// </summary>
        public int? JobTitleId { get; set; }
        public bool NeedChangePassword { get; private set; } = true;
    }
}
