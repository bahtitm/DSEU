using DSEU.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSEU.Domain.Exceptions.Commons
{

    [Serializable]
    public class TerritorialUnitException : Exception
    {

        public TerritorialUnitException() { }
        public TerritorialUnitException(string message, TerritorialUnit territorialUnit) : base(message)
        {

        }
        public TerritorialUnitException(string message, Exception inner) : base(message, inner) { }
        protected TerritorialUnitException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
