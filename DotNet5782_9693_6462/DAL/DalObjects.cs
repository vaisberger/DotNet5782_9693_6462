using IDAL.DO;
using System;

namespace DalObject
{
    public class DalObject
    {
        public static void AddCustomer(Customer c)
        {
            DataSource.customers.Add(c);
        }
        public static void AddStation(BaseStation s)
        {
            DataSource.station.Add(s);
        }
        public static void AddDrone(Drone d)
        {
            DataSource.drones.Add(d);
        }
        public static void AddParcel(Parcel p)
        {
            DataSource.parcels.Add(p);
        }


        public static void MatchDrone(Parcel p)
        {

        }
    }
}
