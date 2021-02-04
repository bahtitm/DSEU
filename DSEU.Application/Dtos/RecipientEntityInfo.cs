using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Dtos
{
    public class RecipientEntityInfo : EntityInfo
    {
        public string Description { get; set; }
        public string PersonalPhotoHash { get; set; }
        public RecipientType RecipientType { get; set; }
    }
}
