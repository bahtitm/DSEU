using DSEU.Domain.Entities;
using MediatR;

namespace DSEU.Application.Modules.Commons.Districts.Commands.CreateDistrict
{
    /// <summary>
    /// Регион под велаятом (Этрап или города в статусе Этрапа)
    /// </summary>
    public class CreateDistrictCommand : IRequest
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Код теретории
        /// </summary>
        public int DistrictCode { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
        public int RegionId { get; set; }
    }
}
