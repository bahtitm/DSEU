using System;

namespace DSEU.Application.Modules.ElasticSearch.Entities
{
    public class ElasticApplicant
    {
        /// <summary>
        /// Familiýasy (öňki familiýasy) (ýuridiki şahs üçin doly ady)
        /// </summary>
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string IdentityDocument { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? DocumentIssueDate { get; set; }
        public string DocumentIssuePlace { get; set; }
        public string Citizenship { get; set; }
        public string RecordLocation { get; set; }
    }
}


