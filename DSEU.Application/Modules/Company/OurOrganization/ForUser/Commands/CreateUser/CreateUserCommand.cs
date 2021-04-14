using MediatR;
using System;

namespace DSEU.Application.Modules.Company.OurOrganization.ForUser.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {        
        
        public string Name { get; set; }
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
        /// ID должности
        /// </summary>
        public int JobTitleId { get; set; }

        public int DistrictId { get; set; }

        public int BranchId { get; set; }

        public string RoleId { get; set; }

        public bool NeedChangePassword { get; private set; } = true;
    }
}
