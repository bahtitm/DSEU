using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Commons
{
    /// <summary>
    /// Валюта
    /// </summary>
    public class Currency:DatabookEntry
    {
        /// <summary>
        /// Код валюты
        /// </summary>
        public string Code { get; set; }
    }
}
