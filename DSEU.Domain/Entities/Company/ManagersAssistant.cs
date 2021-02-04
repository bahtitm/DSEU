using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Company
{
    /// <summary>
    /// Помощник руководителя
    /// </summary>
    public class ManagersAssistant : DatabookEntry
    {
        /// <summary>
        /// Id руководителя
        /// </summary>
        public int ManagerId { get; set; }
        /// <summary>
        /// Id помощника
        /// </summary>
        public int AssistantId { get; set; }
        /// <summary>
        /// Готовит резолюцию для руководителя
        /// </summary>
        public bool PreparesResolution { get; set; }
        /// <summary>
        /// Руководитель
        /// </summary>
        public virtual Employee Manager { get; set; }
        /// <summary>
        /// Помощник
        /// </summary>
        public virtual Employee Assistant { get; set; }

    }
}
