using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Entities.RealEstateRights.Cases;
using System;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.OurOrganization
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : DatabookEntry
    {
        public string LoginName { get; set; } = "";
        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Служебный
        /// </summary>
        public bool IsSystem { get; set; }
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
        /// Почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// ID организационной единицы
        /// </summary>
        //public int? OrganizationalUnitId { get; set; }
        //public virtual OrganizationalUnit OrganizationalUnit { get; set; }
        /// <summary>
        /// ID Организации
        /// </summary>
        public int? JobTitleId { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public virtual JobTitle JobTitle { get; set; }

        public int? DistrictId { get; set; }
        public virtual District District { get; set; }
        //public virtual ICollection<UserLocality> Localities { get; set; }
    }

    /// <summary>
    /// Зона влияния пользователя
    /// </summary>
    //public class UserLocality
    //{
    //    public virtual User User { get; set; }
    //    public int UserId { get; set; }
    //    public int LocalityId { get; set; }
    //    public virtual Locality Locality { get; set; }
    //}
}