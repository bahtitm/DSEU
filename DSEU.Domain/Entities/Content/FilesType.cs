using System.Collections.Generic;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Content
{
    /// <summary>
    /// Типы файлов
    /// </summary>
    public class FilesType : DatabookEntry
    {
        public string Name { get; set; }
        public ICollection<AssociatedApplication> AssociatedApplications { get; set; }
    }
}
