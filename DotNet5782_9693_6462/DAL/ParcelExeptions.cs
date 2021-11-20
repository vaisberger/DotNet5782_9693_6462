using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace IDAL.DO
{
    [Serializable]
    public class ParcelExeptions : Exception
    {
        public ParcelExeptions()
        {

        }
        public ParcelExeptions(string m) : base(m)
        {

        }
        public ParcelExeptions(string m, Exception exp) : base(m, exp)
        {

        }

        protected ParcelExeptions(SerializationInfo info, StreamingContext contex) : base(info, contex)
        {

        }

    }
}
