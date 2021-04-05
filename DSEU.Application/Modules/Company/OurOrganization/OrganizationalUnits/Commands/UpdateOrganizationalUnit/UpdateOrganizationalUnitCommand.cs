using DSEU.Domain.Entities;
using MediatR;

namespace DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Commands.UpdateOrganizationalUnit
{
    public class UpdateOrganizationalUnitCommand : IRequest
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// Имя типа населеного пункта (welayat oba şäher)
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// Ид родителя
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// Вложенность населенного пункта
        /// </summary>
        public int? Level { get; set; }
        /// <summary>
        /// Номер населенного пункта
        /// </summary>
        public int? OrganizationalUnitNumber { get; set; }
    }
}
