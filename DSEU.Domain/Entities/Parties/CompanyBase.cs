using System.Collections.Generic;

namespace DSEU.Domain.Entities.Parties
{
    /// <summary>
    /// Организация
    /// </summary>
    public abstract class CompanyBase : Counterparty
    {
        /// <summary>
        /// Головная орг.
        /// </summary>
        public int? HeadCompanyId { get; set; }
        public virtual CompanyBase HeadCompany { get; set; }
        public virtual ICollection<CompanyBase> Childrens { get; set; }
        /// <summary>
        /// Юрид. наименование
        /// </summary>
        public string LegalName { get; set; }
        /// <summary>
        /// Нередактируемая
        /// </summary>
        /// <remarks>
        /// Системное поле. Признак того, что в карточке организации будет запрет на редактирование. 
        /// При создании нашей организации автоматически создается дублирующая запись организации, 
        /// в таких записях устанавливается запрет на редактирование. Подробнее см. в BusinessUnit.
        /// </remarks>
        public bool IsCardReadOnly { get; set; }
    }
}
