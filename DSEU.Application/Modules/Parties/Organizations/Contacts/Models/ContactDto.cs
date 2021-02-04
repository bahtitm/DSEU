using DSEU.Application.Common.Mapping;
using DSEU.Application.Dtos;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Application.Modules.Parties.Organizations.Contacts.Models
{
    public class ContactDto : DatabookEntryDto, IMapFrom<Contact>
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
