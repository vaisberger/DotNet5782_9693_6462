﻿using IDAL.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalObject
{
    public struct DataSource
    {
        internal static List<Customer> customers = new List<Customer>();
        internal static List<BaseStation> station = new List<BaseStation>();
        internal static List<Drone> drones = new List<Drone>();
        internal static List<Parcel> parcels = new List<Parcel>();
        internal static List<DroneCharge> droneCharges = new List<DroneCharge>();
        public static Random r = new Random();
        internal struct Config
        {

        }
    }

}