using DSEU.Application.Dtos;

namespace DSEU.Application.Modules.RealEstates.Lands.Dtos
{
    public class LandDto : RealEstateDto
    {
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
