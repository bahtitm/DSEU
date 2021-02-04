using System;

namespace DSEU.Domain.Entities.CoreEntities
{
    public class DatabookHistory : IHistory
    {
        public int Id { get; set; }
        public DateTime HistoryDate { get; set; }
        public User User { get; set; }
        public int? UserId { get; set; }
        public int? EntityId { get; set; }
        public EntityTypeGuid? EntityTypeGuid { get; set; }
        public string HostName { get; set; }
        public string UserAgent { get; set; }
        public DatabookHistoryAction Action { get; set; }
        public string Comment { get; set; }
    }
}
