using System;
using System.Runtime.Serialization;

namespace IBL.BO
{
    [Serializable]
    public class BLDroneExption : Exception
    {
        public BLDroneExption()
        {
        }

        public BLDroneExption(string message) : base(message)
        {
        }

        public BLDroneExption(string message, Exception innerException) : base(message, innerException)
        {
        }



        protected BLDroneExption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
