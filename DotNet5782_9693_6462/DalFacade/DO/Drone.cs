﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace DO
{
    public class Drone
    {
        public int Id { get; set; }
        public String Model { get; set; }
        public Weights MaxWeight { get; set; }
        public DroneCharge droneCharge { get; set; }
        //public DroneStatus status { get; set; }
        //public double Battery { get; set; }
        public override string ToString()//print
        {
            return "Id: " + Id + " Model: " + Model + " Max Weight: " + MaxWeight /*+ " Status: " + status*/;
        }
    }
}
