using System.Collections.Generic;

namespace DSEU.Domain.Entities.Commons
{
    public class SplitSettings
    {
        public string Name { get; set; }
        public List<TerritorialUnit> Childs { get; set; } = new();
    }
}
