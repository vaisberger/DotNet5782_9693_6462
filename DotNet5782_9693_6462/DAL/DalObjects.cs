using System;
using IDAL.DO;


namespace DalObject
{
    public class DalObject
    {
        public DalObject() {
            DataSource.Initialize();
        }
        public static void AddCustomer(Customer c)
        {
            DataSource.customers.Add(c);
        }
        //Add a base station to the list of stations
        public static void AddStation(BaseStation s)
        {
            DataSource.station.Add(s);
        }
       // Add a drone  to the list of  drones
        public static void AddDrone(Drone d)
        {
            DataSource.drones.Add(d);
        }
        public static int AddParcel(Parcel p)
        {
            DataSource.parcels.Add(p);
            DataSource.Config.ParcelSerial += 1;
            return DataSource.Config.ParcelSerial;
        }
        public static void Parcelcollection(Parcel p,Drone d)
        {
            p.DroneId = d.Id;
            d.status = DroneStatus.Shipment;
            p.PickedUp = DateTime.Now;

        }

        public static void DisplayStation(int Id)
        {
            DataSource.station.Find(x => x.Id == Id).ToString();
        }
        //Drone display by ID 
        public static void DispalyDrone(int Id)
        {
            DataSource.drones.Find(x => x.Id == Id).ToString();
        }
        //Displays customer by ID 
        public static void DisplayCustomer(int Id)
        {
            DataSource.customers.Find(x => x.Id == Id).ToString();
        }
        //Displays parcel by ID 
        public static void DisplayParcel(int Id)
        {
            DataSource.parcels.Find(x => x.Id == Id).ToString();
        }
        //Displays a list of drone
        public static void DisplayDroneList()
        {
            foreach(Drone d in DataSource.drones)
            {
                Console.WriteLine(d.ToString());
            }
        }
        //Displays a list of base stations
        public static void DisplayStationList()
        {
            foreach (BaseStation b in DataSource.station)
            {
                Console.WriteLine(b.ToString());
            }
        }
        //Displays a list of customer
        public static void DisplayCustomerList()
        {
            foreach (Customer c in DataSource.customers)
            {
                Console.WriteLine(c.ToString());
            }
           
        }
        //Displays a list of parcel
        public static void DisplayParcelList()
        {
            foreach (Parcel p in DataSource.parcels)
            {
                Console.WriteLine(p.ToString());
            }
        }
        //Displays a list of parcel not yet associated with the drone
        public static void DisplayParcelUnmatched()
        {
            foreach (Parcel p in DataSource.parcels)
            {
                if (p.DroneId == 0)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }
        //Displays base stations with available charging stations
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
        //Update parcel  to a drone
        public static void UpdateParcelToDrone(int droneId ,int parcleId)
        {
            for(int i=0; i<DataSource.parcels.Count; i++)
            {
                if(DataSource.parcels[i].Id==parcleId)
                {
                    Parcel P = new Parcel();
                    P = DataSource.parcels[i];
                    P.DroneId = droneId;
                    P.Scheduled = DateTime.Now;
                    DataSource.parcels[i] = P;
                    

                }
            }

        }
       // public static void SendDroneTOCharging(int DronId)

    }
}
