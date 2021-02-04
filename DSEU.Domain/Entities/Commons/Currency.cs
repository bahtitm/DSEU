using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Commons
{
    /// <summary>
    /// Валюта
    /// </summary>
    public class Currency : DatabookEntry
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 3-х значный Буквенный код
        /// </summary>
        public string AlphaCode { get; set; }
        /// <summary>
        /// Сокр. наименование
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Дробная часть
        /// </summary>
        public string FractionName { get; set; }
        /// <summary>
        /// Валюта по умолчанию
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// Цифровой код
        /// </summary>
        public string NumericCode { get; set; }
    }
}
