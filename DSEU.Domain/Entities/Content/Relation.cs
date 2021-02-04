using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Content
{
    /// <summary>
    /// Связь
    /// </summary>
    public class Relation : DatabookEntry
    {
        public int TargetId { get; set; }
        /// <summary>
        /// Назначение
        /// </summary>
       // public ElectronicDocument Target { get; set; }
        public int SourceId { get; set; }
        /// <summary>
        /// Источник
        /// </summary>
        //public ElectronicDocument Source { get; set; }
        public int RelationTypeId { get; set; }
        /// <summary>
        /// Тип связи
        /// </summary>
        public RelationType RelationType { get; set; }
        public string SourceComment { get; set; }
        public string TargetComment { get; set; }
    }

}
