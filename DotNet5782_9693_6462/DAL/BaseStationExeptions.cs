using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace IDAL.DO
{
    [Serializable]
    internal class BaseStationExeptions : Exception
    {
        private int baseStationID;
        private string expMsg;
        public BaseStationExeptions()
       {

       }
        public BaseStationExeptions(string m):base(m)
        {

        }
        public BaseStationExeptions(int basestationid,string exmsg) : this(string.Format(""))
        {
            this.baseStationID = basestationid;
            this.expMsg = exmsg;
        }


    }

}
