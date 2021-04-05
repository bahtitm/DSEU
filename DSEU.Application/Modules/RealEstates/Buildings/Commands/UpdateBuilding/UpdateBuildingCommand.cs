using MediatR;

namespace DSEU.Application.Modules.RealEstates.Buildings.Commands.UpdateBuilding
{
    public class UpdateBuildingCommand : IRequest
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
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
        //public IEnumerable<int> Rights { get; set; }
        /// <summary>
        /// Строение
        /// </summary>
        public string InvertarNumber { get; set; }
        /// <summary>
        /// Жилой Площадь
        /// </summary>
        public double? LiveSquare { get; set; }
        /// <summary>
        /// Общая площадь
        /// </summary>
        public double? CommonSquare { get; set; }
        /// <summary>
        /// Количество этажей
        /// </summary>
        public int? FlatTotal { get; set; }
        /// <summary>
        /// Надземные этажи
        /// </summary>
        public int? AboveGroundFloorsCount { get; set; }
        /// <summary>
        /// подземные этажи
        /// </summary>
        public int? UndergroundFloorsCount { get; set; }
        /// <summary>
        /// Этаж
        /// </summary>
        public int? Flat { get; set; }
        /// <summary>
        /// Номер квартиры
        /// </summary>
        public int? ApartmentNumber { get; set; }
        /// <summary>
        /// Количество этажей
        /// </summary>
        public int? RoomTotal { get; set; }
    }
}
