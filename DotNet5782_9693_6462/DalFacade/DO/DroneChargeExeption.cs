using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace DO
{
    [Serializable]
    public class DroneChargeExeptions:Exception
    {
        public DroneChargeExeptions()
        {

        }
        public DroneChargeExeptions(string m) : base(m)
        {

        }
        public DroneChargeExeptions(string m, Exception exp) : base(m, exp)
        {

        }

        protected DroneChargeExeptions(SerializationInfo info, StreamingContext contex) : base(info, contex)
        {

        }
    }
}
