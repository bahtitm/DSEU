using DSEU.Domain.Entities;

namespace DSEU.Application.Modules.Parties.Shared.Commands
{
    public abstract class BaseUpdateCounterPartCommand
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? RegionId { get; set; }
        public int? LocalityId { get; set; }
        public string LegalAddress { get; set; }
        public string PostAddress { get; set; }
        public string Phones { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string TIN { get; set; }
        public string Note { get; set; }
        public bool Nonresident { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
