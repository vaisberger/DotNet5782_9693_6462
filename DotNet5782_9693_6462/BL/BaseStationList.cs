using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
   public class BaseStationList
    {
        public int Id { get; set; }
        public int Nmae { get; set; }
        public int AvailableChargingStations { get; set; }
        public int BusyChargingStations { get; set; }


    }
}
