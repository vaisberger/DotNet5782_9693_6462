using System;
using IDAL.DO;


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
       
        public static void DisplayDroneList()
        {
            foreach(Drone d in DataSource.drones)
            {
                Console.WriteLine(d.ToString());
            }
        }
        public static void DisplayStationList()
        {
            foreach (BaseStation b in DataSource.station)
            {
                Console.WriteLine(b.ToString());
            }
        }
        public static void DisplayCustomerList()
        {
            foreach (Customer c in DataSource.customers)
            {
                Console.WriteLine(c.ToString());
            }
           
        }
        public static void DisplayParcelList()
        {
            foreach (Parcel p in DataSource.parcels)
            {
                Console.WriteLine(p.ToString());
            }
        }
        public static void DisplayDroneNot()
        {
            foreach(Drone d in DataSource.drones)
            {
                if (d.status==0)
                {
                    Console.WriteLine(d.ToString());
                }
            }
        }
        public static void DisplayAvailableStation()
        {
           foreach (BaseStation b in DataSource.station)
            {
                if( b.Longitude!=0)
                {
                    Console.WriteLine(b.ToString());
                }
            }
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
