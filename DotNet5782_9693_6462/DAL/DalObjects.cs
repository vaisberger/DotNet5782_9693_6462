using System;
using IDAL.DO;


namespace DalObject
{
    public class DalObject
    {
        //constructor
        public DalObject()
        {
            DataSource.Initialize();
        }
        //Add a parcel  to the list of  parcel
        public int AddParcel(Parcel p)
        {
            DataSource.parcels.Add(p);
            DataSource.Config.ParcelSerial += 1;
            return DataSource.Config.ParcelSerial;
        }
        //Add customer to the list of customer
        public void AddCustomer(Customer c)
        {
            DataSource.customers.Add(c);
        }

        //Add a base station to the list of stations
        public void AddStation(BaseStation s)
        {
            DataSource.station.Add(s);
        }
        // Add a drone  to the list of  drones
        public void AddDrone(Drone d)
        {
            DataSource.drones.Add(d);
        }
        //Update parcel  to a drone
        public void UpdateParcelToDrone(int droneId, int parcleId)
        {
            for (int i = 0; i < DataSource.parcels.Count; i++)
            {
                if (DataSource.parcels[i].Id == parcleId)
                {
                    Parcel P = new Parcel();
                    P = DataSource.parcels[i];
                    P.DroneId = droneId;
                    P.Scheduled = DateTime.Now;
                    DataSource.parcels[i] = P;


                }
            }
        }

        //Parcel collection drone
        public void Parcelcollection(Parcel p, Drone d)
        {
            p.DroneId = d.Id;
            d.status = DroneStatus.Shipment;
            p.PickedUp = DateTime.Now;

        }
        //Delivery of a parcel to the customer
        public void ParcelDelivery(Parcel p, Customer c)
        {
            p.SenderId = c.Id;
            p.TargetId = c.Id;
            p.Delivered = DateTime.Now;
        }
        //Sending drone for charging at a base station
        public void ChargeDrone(Drone d, BaseStation s)
        {
            d.status = DroneStatus.Maitenance;
            DroneCharge dc = new DroneCharge();
            dc.DroneId = d.Id;
            dc.StatioId = s.Id;
            DataSource.droneCharges.Add(dc);

        }
        //Discharge drone from charging at base station
        public void DischargeDrone(Drone d)
        {
            DroneCharge dc;
            d.status = DroneStatus.Available;
            for (int i = 0; i < DataSource.droneCharges.Count; i++)
            {
                if (DataSource.droneCharges[i].DroneId == d.Id)
                {
                    dc = DataSource.droneCharges[i];
                    DataSource.droneCharges.Remove(dc);
                }
            }
        }

        ////Drone display by ID
        public void DisplayStation(int Id)
        {
            DataSource.station.Find(x => x.Id == Id).ToString();
        }
        //Drone display by ID 
        public void DispalyDrone(int Id)
        {
            DataSource.drones.Find(x => x.Id == Id).ToString();
        }
        //Displays customer by ID 
        public void DisplayCustomer(int Id)
        {
            DataSource.customers.Find(x => x.Id == Id).ToString();
        }
        //Displays parcel by ID 
        public void DisplayParcel(int Id)
        {
            DataSource.parcels.Find(x => x.Id == Id).ToString();
        }
        //Displays a list of drone
        public void DisplayDroneList()
        {
            foreach (Drone d in DataSource.drones)
            {
                Console.WriteLine(d.ToString());
            }
        }
        //Displays a list of base stations
        public void DisplayStationList()
        {
            foreach (BaseStation b in DataSource.station)
            {
                Console.WriteLine(b.ToString());
            }
        }
        //Displays a list of customer
        public void DisplayCustomerList()
        {
            foreach (Customer c in DataSource.customers)
            {
                Console.WriteLine(c.ToString());
            }

        }
        //Displays a list of parcel
        public void DisplayParcelList()
        {
            foreach (Parcel p in DataSource.parcels)
            {
                Console.WriteLine(p.ToString());
            }
        }
        //Displays a list of parcel not yet associated with the drone
        public void DisplayParcelUnmatched()
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
        public  void DisplayAvailableStation()
        {
            foreach (BaseStation b in DataSource.station)
            {
                if (b.Longitude != 0)
                {
                    Console.WriteLine(b.ToString());
                }
            }
        }
       
       
       
    }
}
