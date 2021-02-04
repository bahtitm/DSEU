using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.Company;

namespace DSEU.Application.Dtos.Company
{
    public class BusinessUnitDto : RecipientBaseDto, IMapFrom<BusinessUnit>
    {
        /// <summary>
        /// ИНН
        /// </summary>
        public string TIN { get; set; }
        /// <summary>
        /// Ид Населенного пункта
        /// </summary>
        public int? LocalityId { get; set; }
        /// <summary>
        /// Телефоны
        /// </summary>
        public string Phones { get; set; }
        /// <summary>
        /// Юрид. наименование
        /// </summary>
        public string LegalName { get; set; }
        /// <summary>
        /// Регион
        /// </summary>
        public int? RegionId { get; set; }
        /// <summary>
        /// Юридический адрес
        /// </summary>
        public string LegalAddress { get; set; }
        /// <summary>
        /// Почтовый адрес
        /// </summary>
        public string PostalAddress { get; set; }
        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// Ид Руководителя (Сотрудник)
        /// </summary>
        public int? CEO { get; set; }
        /// <summary>
        /// Эл. почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Сайт
        /// </summary>
        public string Homepage { get; set; }
        /// <summary>
        /// Номер счета
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// Ид Банка
        /// </summary>
        public int? BankId { get; set; }
        public int? HeadCompanyId { get; set; }
        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; }
    }
}
