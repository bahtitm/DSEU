﻿using MediatR;

namespace DSEU.Application.Modules.RealEstates.Lands.Commands.CreateLand
{
    /// <summary>
    /// Земелный участок
    /// </summary>
    public class CreateLandCommand : IRequest
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Цель
        /// </summary>
        public string Purpose { get; set; }
        /// <summary>
        /// Кадастровая цена
        /// </summary>
        public decimal? CadastralCost { get; set; }
        /// <summary>
        /// Цена сделки
        /// </summary>
        public decimal? DealCost { get; set; }
        /// <summary>
        /// Валюта
        /// </summary>
        public int? CurrencyId { get; set; }
        /// <summary>
        /// Кадастровый номер
        /// </summary>
        public string CadastralNumber { get; set; }
        /// <summary>
        /// Мнимый кадастровый номер
        /// </summary>
        public string VirtualCadastralNumber { get; set; }
        /// <summary>
        /// Площадь
        /// </summary>
        public double Square { get; set; }
    }
}
