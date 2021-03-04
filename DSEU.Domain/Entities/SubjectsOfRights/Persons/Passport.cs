using System;

namespace DSEU.Domain.Entities.SubjectsOfRights.Persons
{
    public class Passport : IdentityDocument
    {
        public string Number { get; set; }

        public string IssuedBy { get; set; }

        public DateTime? Date { get; set; }
    }
}