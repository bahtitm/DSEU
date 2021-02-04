using System.Collections.Generic;

namespace DSEU.Application.Dtos
{
    public class MetadataDto
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public bool IsManagerAssistant { get; set; }
        public object AccessRights { get; set; }
        /// <summary>
        /// Хеш фотографии
        /// </summary>
        public string PersonalPhotoHash { get; set; }
    }
}
