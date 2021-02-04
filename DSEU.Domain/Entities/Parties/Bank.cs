namespace DSEU.Domain.Entities.Parties
{
    /// <summary>
    /// Банк
    /// </summary>
    public class Bank : CompanyBase
    {
        /// <summary>
        /// Банковский идентификационный код
        /// </summary>
        public string BIC { get; set; }
        /// <summary>
        /// Корр. счет
        /// </summary>
        public string CorrespondentAccount { get; set; }
    }
}
