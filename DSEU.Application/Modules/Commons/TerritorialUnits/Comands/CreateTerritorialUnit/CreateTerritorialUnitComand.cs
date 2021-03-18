using DSEU.Domain.Entities;
using MediatR;

namespace DSEU.Application.Modules.Commons.TerritorialUnits.Comands.CreateTerritorialUnit
{
    public class CreateTerritorialUnitComand : IRequest
    {
        public int Id { get; set; }
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
        public Status Status { get; set; }
        public int? ParentId { get; set; }

    }
}
