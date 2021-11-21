using System;
using System.Runtime.Serialization;

namespace IBL.BO
{
    [Serializable]
    public class BLCustomerExption : Exception
    {
        public BLCustomerExption()
        {
        }

        public BLCustomerExption(string message) : base(message)
        {
        }

        public BLCustomerExption(string message, Exception innerException) : base(message, innerException)
        {
        }

      

        protected BLCustomerExption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}