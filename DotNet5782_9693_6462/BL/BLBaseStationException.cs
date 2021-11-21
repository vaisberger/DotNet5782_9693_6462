using System;
using System.Runtime.Serialization;

namespace IBL
{
    [Serializable]
    internal class BLBaseStationException : Exception
    {
        public BLBaseStationException()
        {
        }

        public BLBaseStationException(string message) : base(message)
        {
        }

        public BLBaseStationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BLBaseStationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}