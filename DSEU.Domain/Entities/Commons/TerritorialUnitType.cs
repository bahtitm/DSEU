using DSEU.Domain.Entities.CoreEntities;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.Commons
{
    public class TerritorialUnitType : DatabookEntry
    {
        protected TerritorialUnitType() { }
        /// <summary>
        /// Неизменяемая
        /// </summary>
        public bool IsReadOnly { get; set; }
        public string PostFix { get; }

        public TerritorialUnitType(string name,string postFix)
        {
            Name = name;
            PostFix = postFix;
        }

        public virtual ICollection<TerritorialUnit> TerritorialUnits { get; set; }
    }
}
