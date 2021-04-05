using MediatR;
using System;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.UpdateUser
{
    public class UpdateUserComand : IRequest
    {
        public int Id { get; set; }
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
        /// Почта
        /// </summary>
        public string Email { get; set; }
    }
}
