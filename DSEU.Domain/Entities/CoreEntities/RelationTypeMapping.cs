namespace DSEU.Domain.Entities.CoreEntities
{
    public class RelationTypeMapping : BaseEntity
    {
        public RelationType RelationType { get; set; }
        public int Number { get; set; }
        /// <summary>
        /// Источник
        /// </summary>
        public string SourceType { get; set; }
        /// <summary>
        /// Назначение
        /// </summary>
        public string TargetType { get; set; }
        /// <summary>
        /// Заполнить свойство
        /// </summary>
        public string TargetProperty { get; set; }
    }
}
