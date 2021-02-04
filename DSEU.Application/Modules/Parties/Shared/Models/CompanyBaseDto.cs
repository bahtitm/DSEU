namespace DSEU.Application.Modules.Parties.Shared.Models
{
    public abstract class CompanyBaseDto : CounterPartBaseDto
    {
        /// <summary>
        /// Головная орг.
        /// </summary>
        public int? HeadCompanyId { get; set; }
        /// <summary>
        /// Юрид. наименование
        /// </summary>
        public string LegalName { get; set; }
        public bool IsCardReadOnly { get; set; }
    }
}
