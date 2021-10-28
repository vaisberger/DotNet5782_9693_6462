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
            public Weights weight { get; set; }
            public DroneStatus status { get; set; }
            public double Battery { get; set; }
            public static void ToString(int Id, string Model, Weights weight, DroneStatus status)
            {
                Console.WriteLine("Id: {0} Model: {1} Weight: {2} Status: {3}", Id, Model, weight, status);
            }
        }
    }
}
