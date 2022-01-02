using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B0
{
# IdExeptions
    [Serializable]
 public class DroneExistsException : Exception
    {
        public int ID;
        public DroneExistsException(string msg, Exception innerException) : base(msg, innerException) => ID = ((DO.IDExistsInTheSystem)innerException).ID;
        public override string ToString() => base.ToString() + $", Drone ID : {ID} allready exists in the system can't finish the adding prosses";

    }

    [Serializable]
    public class ParcelExistsException : Exception
    {
        public int ID;
        public ParcelExistsException(string msg, Exception innerException) : base(msg, innerException) => ID = ((DO.IDExistsInTheSystem)innerException).ID;
        public override string ToString() => base.ToString() + $", Parcel ID : {ID} allready exists in the system can't finish the adding prosses";

    }

    [Serializable]
    public class BaseStationExistsException : Exception
    {
        public int ID;
        public BaseStationExistsException(string msg, Exception innerException) : base(msg, innerException) => ID = ((DO.IDExistsInTheSystem)innerException).ID;
        public override string ToString() => base.ToString() + $", BaseStation ID : {ID} allready exists in the system can't finish the adding prosses";

    }

    [Serializable]
    public class CustomerExistsException : Exception
    {
        public int ID;
        public CustomerExistsException(string msg, Exception innerException) : base(msg, innerException) => ID = ((DO.IDExistsInTheSystem)innerException).ID;
        public override string ToString() => base.ToString() + $", Customer ID : {ID} allready exists in the system can't finish the adding prosses";

    }
#endregion


}
