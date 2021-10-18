using DalObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    namespace DO
    {
        public struct Drone
        {
            public int Id { get; set; }
            public String Model { get; set; }
            public Weight  { get; set; }
            public DroneStatus   {get; set; }
            public double Battery { get; set; }
    }
}
