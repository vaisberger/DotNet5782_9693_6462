using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace BL
{
    [Serializable]
    class BLBaseStationExption:Exception
    {
        public BLBaseStationExption()
        {
        }

        public BLBaseStationExption(string message) : base(message)
        {
        }

        public BLBaseStationExption(string message, Exception innerException) : base(message, innerException)
        {
        }



        protected BLBaseStationExption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
