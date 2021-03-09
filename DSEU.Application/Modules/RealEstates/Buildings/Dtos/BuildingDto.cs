using DSEU.Application.Common.Mapping;
using DSEU.Application.Dtos;
using DSEU.Domain.Entities.RealEstates;

namespace DSEU.Application.Modules.RealEstates.Buildings.Dtos
{
    /// <summary>
    /// Строение
    /// </summary>
    public class BuildingDto : RealEstateDto, IMapFrom<Building>
    {
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
