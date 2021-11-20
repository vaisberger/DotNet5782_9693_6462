
using IBL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class DroaneList
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public Weights MaxWeight { get; set; }
        public DroneStatus status { get; set; }
        public double Battery { get; set; }
        public Location location { get; set; }
        public int ParcelNumberPasses { get; set; }
    }
}
