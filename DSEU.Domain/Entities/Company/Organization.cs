using DSEU.Domain.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSEU.Domain.Entities.Company
{
    /// <summary>
    /// Организация
    /// </summary>
    public abstract class Organization:BaseEntity
    {
        public string Name  { get; set; }
        /// <summary>
        /// представитель
        /// </summary>
        public Person Representative { get; set; }

        public string Address { get; set; }
    }
}
