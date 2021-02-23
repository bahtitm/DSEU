using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSEU.Domain.Entities.RealEstateRights
{
    public abstract class Document:BaseEntity
    {
        public DocumentType DocumentType { get; set; }
        public string Name { get; set; }
    }
}
