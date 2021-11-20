using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace IDAL.DO
{
    [Serializable]
    public class DroneExeptions:Exception
    {
        public DroneExeptions()
        {

        }
        public DroneExeptions(string m) : base(m)
        {

        }
        public DroneExeptions(string m, Exception exp) : base(m, exp)
        {

        }

        protected DroneExeptions(SerializationInfo info, StreamingContext contex) : base(info, contex)
        {

        }
    }
}
