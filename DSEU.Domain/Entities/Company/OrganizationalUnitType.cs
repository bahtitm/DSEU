using DSEU.Domain.Entities.CoreEntities;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.Company
{
    public class OrganizationalUnitType : DatabookEntry
    {
        /// <summary>
        /// Типы юнитов в рег службе
        /// </summary>
        protected OrganizationalUnitType() { }
        /// <summary>
        /// Неизменяемая
        /// </summary>
        public bool IsReadOnly { get; set; }
        public string PostFix { get; }
        public OrganizationalUnitType(string name, string postFix)
        {
            Name = name;
            PostFix = postFix;
        }
        public virtual ICollection<OrganizationalUnit> OrganizationalUnits { get; set; }
    }
}