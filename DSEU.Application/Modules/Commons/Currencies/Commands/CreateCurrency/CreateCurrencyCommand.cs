using MediatR;
using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Commons.Currencies.Commands.CreateCurrency
{
    public class CreateCurrencyCommand : IRequest
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
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
