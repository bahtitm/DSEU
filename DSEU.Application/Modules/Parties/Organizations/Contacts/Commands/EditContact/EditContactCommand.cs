using MediatR;
using DSEU.Application.Modules.Parties.Organizations.Contacts.Models;

namespace DSEU.Application.Modules.Parties.Organizations.Contacts.Commands.EditContact
{
    public class EditContactCommand : IRequest<ContactDto>
    {
        public int Id { get; set; }
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

    }
}
