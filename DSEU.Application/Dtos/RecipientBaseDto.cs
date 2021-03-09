using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Dtos
{
    public abstract class RecipientBaseDto : DatabookEntryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public RecipientType RecipientType { get; set; }
        public bool IsSystem { get; set; }
    }
}
