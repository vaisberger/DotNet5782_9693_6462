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


        public static void DisplayStation(int Id)
        {
            DataSource.station.Find(x => x.Id == Id).ToString();
        }
        public static void DispalyDrone(int Id)
        {
            DataSource.drones.Find(x => x.Id == Id).ToString();
        }
        public static void DisplayCostomer(int Id)
        {
            DataSource.customers.Find(x => x.Id == Id).ToString();
        }
        public static void DisplayParcel(int Id)
        {
            DataSource.parcels.Find(x => x.Id == Id).ToString();

        }

        public static void MatchDrone(Parcel p)
        {
            DataSource.drones.Find(x => x.Id == p.Droneld);
            
        }

        public static void ParcelCollection(Drone d)
        {

        }
        public static void ParcelDelivery(Parcel p)
        {

        }
        public static void ChargeDrone(Drone d)
        {

        }
        public static void DischargeDrone(Drone d)
        {

        }
    }
}
