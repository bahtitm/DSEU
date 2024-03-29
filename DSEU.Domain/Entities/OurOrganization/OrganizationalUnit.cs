using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.OurOrganization
{
    /// <summary>
    /// Unit-ы в рег. службе 
    /// </summary>
    /// todo надо еще подумать
    public class OrganizationalUnit : DatabookEntry
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