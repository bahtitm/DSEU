using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Commons
{
    /// <summary>
    /// определенная територия 
    /// </summary>
    public class TerritorialUnit : DatabookEntry
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
    }
}