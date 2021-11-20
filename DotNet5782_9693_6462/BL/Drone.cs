using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL
{
    namespace BO
    {
        public struct Drone
        {
            public int Id { get; set; }
            public String Model { get; set; }
            public Weights MaxWeight { get; set; }
            public DroneStatus status { get; set; }
            public double Battery { get; set; }
           // public Location Location { get; set; }

           

        }
    }
}
}