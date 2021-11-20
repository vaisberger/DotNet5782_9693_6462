using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace IDAL.DO
{
    [Serializable]
    public class BaseStationExeptions : Exception
    {
        public BaseStationExeptions()
       {

       }
        public BaseStationExeptions(string m):base(m)
        {

        }
        public BaseStationExeptions(string m,Exception exp) : base(m,exp)
        {

        }

        protected BaseStationExeptions(SerializationInfo info,StreamingContext contex) : base(info, contex)
        {

        }
    }

}
