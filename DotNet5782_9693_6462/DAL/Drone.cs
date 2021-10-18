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
        public class Drone
        {
            public int Id { get; set; }
            public String Model { get; set; }
            public Weight weight { set; get; }
            public DroneStatus   {set; get; }
            public double Battery { get; set; }
    }
}
