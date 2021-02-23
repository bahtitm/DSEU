using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSEU.Domain.Entities.Persons
{
    public class Passport:IdentityDocument
    {
        public string Number { get; set; }

        public string IssuedBy { get; set; }

        public DateTime? Date { get; set; }
    }
}
