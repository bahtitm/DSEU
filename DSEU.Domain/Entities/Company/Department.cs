using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Company
{
    /// <summary>
    /// Подразделение
    /// </summary>
    public class Department : Group
    {
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
        /// ИД головного подразделения
        /// </summary>
        public int? HeadOfficeId { get; set; }
        /// <summary>
        /// ИД организации
        /// </summary>
        public int BusinessUnitId { get; set; }
        /// <summary>
        /// ИД руководителя (сотрудник)
        /// </summary>
        public int? ManagerId { get; set; }
       
        public Department HeadOffice { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        public Employee Manager { get; set; }
    }
}
