using System;
using System.Runtime.Serialization;

namespace IBL
{
    [Serializable]
    internal class BLDroneExptions : Exception
    {
        public BLDroneExptions()
        {
        }

        public BLDroneExptions(string message) : base(message)
        {
        }

        public BLDroneExptions(string message, Exception innerException) : base(message, innerException)
        {
        }

       

        protected BLDroneExptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}