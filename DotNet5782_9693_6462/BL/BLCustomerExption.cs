using System;
using System.Runtime.Serialization;

namespace IBL.BO
{
    [Serializable]
    public class BLParcelExption : Exception
    {
        public BLParcelExption()
        {
        }

        public BLParcelExption(string message) : base(message)
        {
        }

        public BLParcelExption(string message, Exception innerException) : base(message, innerException)
        {
        }

      

        protected BLParcelExption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}