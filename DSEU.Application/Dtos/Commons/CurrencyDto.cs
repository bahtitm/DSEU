using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.Commons;

namespace DSEU.Application.Dtos.Commons
{
    public class CurrencyDto : DatabookEntryDto, IMapFrom<Currency>
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Буквенный код
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
