using DSEU.Application.Common.Mapping;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Dtos
{
    public class RecipientDto : RecipientBaseDto, IMapFrom<Recipient>
    {
        public string PersonalPhotoHash { get; set; }
    }
}
