using MediatR;

namespace DSEU.Application.Modules.Commons.TerritorialUnits.Commands.CreateTerritorialUnit
{
    public class CreateTerritorialUnitComand : IRequest
    {

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Имя типа населеного пункта (welayat oba şäher)
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        //public Status Status { get; set; }
        public int? ParentId { get; set; }

        public int DistrictId { get; set; }
    }
}
