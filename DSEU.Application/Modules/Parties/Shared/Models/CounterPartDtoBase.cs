using DSEU.Application.Dtos;

namespace DSEU.Application.Modules.Parties.Shared.Models
{
    public abstract class CounterPartBaseDto : DatabookEntryDto
    {
        /// <summary>
        /// ИНН
        /// </summary>
        public string TIN { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? RegionId { get; set; }
        public int? LocalityId { get; set; }
        /// <summary>
        /// Юридический адрес
        /// </summary>
        public string LegalAddress { get; set; }
        /// <summary>
        /// Почтовый адрес
        /// </summary>
        public string PostAddress { get; set; }
        public string Phones { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Note { get; set; }
        /// <summary>
        /// Нерезидент
        /// </summary>
        public bool Nonresident { get; set; }
        /// <summary>
        /// Номер счета
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// Банк
        /// </summary>
        public int? BankId { get; set; }
        /// <summary>
        /// Тип контрагента (дискриминатор)
        /// </summary>
        public string Type { get; set; }
    }
}
