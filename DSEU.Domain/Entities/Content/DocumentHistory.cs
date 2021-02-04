using System;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Content
{
    /// <summary>
    /// История
    /// </summary>
    public class DocumentHistory : IHistory
    {
        public int? Version { get; set; }
        public int Id { get; set; }
        public DateTime HistoryDate { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
        public int? EntityId { get; set; }
        public EntityTypeGuid? EntityTypeGuid { get; set; }
        public string HostName { get; set; }
        public string UserAgent { get; set; }
        public DocumentHistoryAction Action { get; set; }
        public string Comment { get; set; }
    }
}
