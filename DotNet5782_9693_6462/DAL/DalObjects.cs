using System;
using IDAL.DO;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


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
        public void AddStation(ref BaseStation s)
        {
            DataSource.stations.Add(s);
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
        public void Parcelcollection(int p, int d)
        {
            for (int i = 0; i < DataSource.parcels.Count; i++)
            {
                if (DataSource.parcels[i].Id == p)
                {
                    //d.status = DroneStatus.Shipment;
                    Parcel P = new Parcel();
                    P = DataSource.parcels[i];
                    P.DroneId = d;
                    P.PickedUp = DateTime.Now;
                    DataSource.parcels[i] = P;


                }
            }
            for (int i = 0; i < DataSource.drones.Count; i++)
            {
                if (DataSource.drones[i].Id == d)
                {
                    Drone D = new Drone();
                    D = DataSource.drones[i];
                    //D.status = DroneStatus.Shipment;
                    DataSource.drones[i] = D;
                }
            }


        }
        //Delivery of a parcel to the customer
        public void ParcelDelivery(int p, int c)
        {
            for (int i = 0; i < DataSource.parcels.Count; i++)
            {
                if (DataSource.parcels[i].Id == p)
                {
                    //d.status = DroneStatus.Shipment;
                    Parcel P = new Parcel();
                    P = DataSource.parcels[i];
                    P.SenderId = c;
                    P.TargetId = c;
                    P.Delivered = DateTime.Now;
                    DataSource.parcels[i] = P;

                }
            }
        }
        //Sending drone for charging at a base station
        public void ChargeDrone(int d, int s)
        {
            for (int i = 0; i < DataSource.drones.Count; i++)
            {
                if (DataSource.drones[i].Id == d)
                {
                    Drone D = new Drone();
                    D = DataSource.drones[i];
                   // D.status = DroneStatus.Maitenance;
                    DataSource.drones[i] = D;
                }
            }
            for (int i = 0; i < DataSource.stations.Count; i++)
            {
                if (DataSource.stations[i].Id == s)
                {
                    BaseStation S = new BaseStation();
                    S = DataSource.stations[i];
                    S.ChargeSlots -= 1;
                    DataSource.stations[i] = S;
                }
            }
            DroneCharge dc = new DroneCharge();
            dc.DroneId = d;
            dc.StatioId = s;
            DataSource.droneCharges.Add(dc);

        }
        //Discharge drone from charging at base station
        public void DischargeDrone(int d)
        {
            DroneCharge dc;
            for (int i = 0; i < DataSource.drones.Count; i++)
            {
                if (DataSource.drones[i].Id == d)
                {
                    Drone D = new Drone();
                    D = DataSource.drones[i];
                    //D.status = DroneStatus.Available;
                    DataSource.drones[i] = D;
                }
            }
            for (int i = 0; i < DataSource.droneCharges.Count; i++)
            {
                if (DataSource.droneCharges[i].DroneId == d)
                {
                    dc = DataSource.droneCharges[i];
                    DataSource.droneCharges.Remove(dc);
                }
            }

        }

        ////Drone display by ID
        public void DisplayStation(int Id)
        {
            for(int i=0; i<DataSource.stations.Count; i++)
            {
                if(DataSource.stations[i].Id==Id)
                {
                    Console.WriteLine(DataSource.stations[i].ToString());
                    return;
                }
            }
            
        }
        public void DisplayDrone(int Id)
        {
            for (int i = 0; i < DataSource.drones.Count; i++)
            {
                if (DataSource.drones[i].Id == Id)
                {
                    Console.WriteLine(DataSource.drones[i].ToString());

                    return;
                }
            }
        }
  
        //Displays customer by ID 
        public void DisplayCustomer(int Id)
        {
            for(int i=0; i<DataSource.customers.Count; i++)
            {
                if (DataSource.customers[i].Id==Id)
                {
                    Console.WriteLine(DataSource.customers[i].ToString());
                    return;
                }
            }
        }
        //Displays parcel by ID 
        public void DisplayParcel(int Id)
        {
            for(int i=0; i<DataSource.parcels.Count;i++)
            {
                if(DataSource.parcels[i].Id==Id)
                {
                    Console.WriteLine(DataSource.parcels[i].ToString());
                    return;
                }
            }
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
            foreach (BaseStation b in DataSource.stations)
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
        public void DisplayAvailableStation()
        {
            foreach (BaseStation b in DataSource.stations)
            {
                if (b.Longitude != 0)
                {
                    Console.WriteLine(b.ToString());
                }
            }
        }



    }
}


