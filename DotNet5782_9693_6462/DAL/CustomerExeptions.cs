using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace IDAL.DO
{
    [Serializable]
    public class CustomerExeptions:Exception
    {
        public CustomerExeptions()
        {

        }
        public CustomerExeptions(string m) : base(m)
        {

        }
        public CustomerExeptions(string m, Exception exp) : base(m, exp)
        {

        }

        protected CustomerExeptions(SerializationInfo info, StreamingContext contex) : base(info, contex)
        {

        }
    }
}
