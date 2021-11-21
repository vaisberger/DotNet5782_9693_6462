using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    namespace BO
    {
        class BaseStation
        {
            public int Id { get; set; }
            public int Name { get; set; }
            public Location location { get; set; }
            public int AvailableChargingStations { get; set; }
            public List<DroneInCharging> DroneInChargings { get; set; }

        }
    }
}
