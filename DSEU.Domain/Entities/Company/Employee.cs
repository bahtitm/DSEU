using System.Collections.Generic;
using DSEU.Domain.Entities.CoreEntities;


namespace DSEU.Domain.Entities.Company
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : User
    {
        /// <summary>
        /// Рабочий телефон
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Эл. почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// ID Подразделения
        /// </summary>
        public int? DepartmentId { get; set; }
        /// <summary>
        /// ID должности
        /// </summary>
        public int? JobTitleId { get; set; }
       
        public virtual ICollection<ManagersAssistant> Assistants { get; set; }
        public virtual Department Department { get; set; }
        public virtual JobTitle JobTitle { get; set; }

        //todo yest w netije
        //public virtual PersonalSetting PersonalSetting { get; set; }
    }
}
