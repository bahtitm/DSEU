using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Commons
{
    /// <summary>
    /// Причина
    /// </summary>
    public class Reason : DatabookEntry
    {
        public ReasonCategory ReasonCategory { get; set; }
    }
}
