using DSEU.Application.Dtos;

namespace DSEU.Application.Modules.Company.OurOrganization.OrganizationalUnits.Dtos
{
    public class OrganizationalUnitDto : DatabookEntryDto
    {
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
