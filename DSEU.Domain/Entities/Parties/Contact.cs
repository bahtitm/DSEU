using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Parties
{
    /// <summary>
    /// Контакт
    /// </summary>
    /// <remarks>Справочник предназначен для хранения сведений о представителях организаций-контрагентов для быстрой связи с ними.</remarks>
    public class Contact : DatabookEntry
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Организация
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Подразделение
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string JobTitle { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Факс
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// Эл. почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Сайт
        /// </summary>
        public string Homepage { get; set; }

        public CompanyBase Company { get; set; }
    }
}
