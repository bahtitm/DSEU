using System.Collections.Generic;
using DSEU.Domain.Entities.Commons;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Entities.Parties;

namespace DSEU.Domain.Entities.Company
{
    /// <summary>
    /// Наша организация
    /// </summary>
    public class BusinessUnit : Group
    {
        /// <summary>
        /// ИНН (Налоговый номер)
        /// </summary>
        public string TIN { get; set; }
        /// <summary>
        /// ИД Населенного пункта
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
        /// ИД региона
        /// </summary>
        public int? RegionId { get; set; }
        /// <summary>
        /// Ид Головной орг.
        /// </summary>
        public int? HeadCompanyId { get; set; }
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
        /// ИД Руководителя (Сотрудник)
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
        /// ИД Банка
        /// </summary>
        public int? BankId { get; set; }
        /// <summary>
        /// Код организации
        /// </summary>
        public string Code { get; set; }
        public Region Region { get; set; }
        public int CompanyId { get; set; }
        public Parties.Company Company { get; set; }
        public virtual Locality Locality { get; set; }
        public virtual BusinessUnit HeadCompany { get; set; }
        public virtual Employee BusinessUnitHead { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

        public void ReevaluateDepartmentsDescription()
        {
            foreach (var item in Departments)
            {
                item.Description = Name;
            }
        }
    }
}
