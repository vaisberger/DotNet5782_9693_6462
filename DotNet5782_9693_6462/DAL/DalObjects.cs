using System;
using IDAL.DO;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public interface IEnumerable<out list> : IEnumerable
{
    IEnumerable<list> GetEnumerable();
}
namespace DalObject
{

    public class DalObject:IDal
    {

        //constructor
        public DalObject()
        {
            DataSource.Initialize();
        }

        //Add a parcel  to the list of  parcel
        int IDal.AddParcel(Parcel p)
        {
            if (DataSource.parcels.Exists(parcel => parcel.Id == p.Id))
            {
                throw new ParcelExeptions($"parcel {p.Id} allready exists ");
            }
            DataSource.parcels.Add(p);
            DataSource.Config.ParcelSerial += 1;
            return DataSource.Config.ParcelSerial;
        }
        //Add customer to the list of customer
         void IDal.AddCustomer(Customer c)
        {
            if (DataSource.customers.Exists(customer => customer.Id == c.Id))
            {
                throw new CustomerExeptions($"customer {c.Id} allready exists ");
            }
            DataSource.customers.Add(c);
        }

        //Add a base station to the list of stations
         void IDal.AddStation(BaseStation s)
        {
            if (DataSource.stations.Exists(station => station.Id == s.Id))
            {
                throw new BaseStationExeptions($"station {s.Id} allready exists ");
            }
            DataSource.stations.Add(s);
        }
        // Add a drone  to the list of  drones
         void IDal.AddDrone(Drone d)
        {
            if (DataSource.drones.Exists(drone => drone.Id == d.Id))
            {
                throw new DroneExeptions($"drone {d.Id} allready exists ");
            }
            DataSource.drones.Add(d);
        }
         void IDal.UpdateDrone(int id, String model)
        {
            var d = DataSource.drones.FirstOrDefault(X => X.Id == id);
            d.Model = model;
        }
        void IDal.UpdateBaseStation(int id, int name, int chargeslots)
        {
            var s = DataSource.stations.FirstOrDefault(bs => bs.Id == id);
            if (name !=-1)
            {
                s.Name = name;
            }
            if (chargeslots != -1)
            {
                s.ChargeSlots = chargeslots;
            }
        }
        void IDal.UpdateCustomer(int id, String name, String phone)
        {
            var c = DataSource.customers.FirstOrDefault(cs => cs.Id == id);
            if (name != "")
            {
                c.Name = name;
            }
            if (phone != "")
            {
                c.Phone = phone;
            }
        }
        //Update parcel  to a drone
        void IDal.UpdateParcelToDrone(int droneId, int parcleId)
        {
            if (DataSource.parcels.Exists(parcel => parcel.Id != parcleId))
            {
                throw new ParcelExeptions($"parcel {parcleId} dosen't exists ");
            }
            if (DataSource.drones.Exists(drone => drone.Id != droneId))
            {
                throw new DroneExeptions($"drone {droneId} dosen't exists ");
            }
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
        void IDal.Parcelcollection(int p, int d)
        {
            if (DataSource.parcels.Exists(parcel => parcel.Id != p))
            {
                throw new ParcelExeptions($"parcel {p} dosen't exists ");
            }
            if (DataSource.drones.Exists(drone => drone.Id != d))
            {
                throw new DroneExeptions($"drone {d} dosen't exists ");
            }
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
        void IDal.ParcelDelivery(int p, int c)
        {
            if (DataSource.customers.Exists(customer => customer.Id != c))
            {
                throw new CustomerExeptions($"customer {c} dosen't exists ");
            }
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
        void IDal.ChargeDrone(int d, int s)
        {
            if (DataSource.drones.Exists(drone => drone.Id != d))
            {
                throw new DroneExeptions($"drone {d} dosen't exists ");
            }
            if (DataSource.stations.Exists(station => station.Id != s))
            {
                throw new BaseStationExeptions($"station {s} dosen't exists ");
            }
            if (DataSource.droneCharges.Exists(drone => drone.DroneId == d))
            {
                throw new DroneChargeExeptions($"drone {d} allready in charging ");
            }
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
        void IDal.DischargeDrone(int d)
        {
            if (DataSource.droneCharges.Exists(drone => drone.DroneId == d))
            {
                throw new DroneChargeExeptions($"station {d} dosen't exists ");
            }
            DroneCharge dc;
            for (int i = 0; i < DataSource.drones.Count; i++)
            {
                if (DataSource.drones[i].Id == d)
                {
                    Drone D = new Drone();
                    D = DataSource.drones[i];
                    DataSource.drones[i] = D;
                }
            }
            DroneCharge dcs =DataSource.droneCharges.FirstOrDefault(x => x.DroneId == d);
            BaseStation s = DataSource.stations.FirstOrDefault(x => x.Id == dcs.StatioId);
            s.ChargeSlots += 1;
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
        BaseStation IDal.DisplayStation(int Id)
        {
            BaseStation s = new BaseStation();
            if (DataSource.stations.Exists(station => station.Id != Id))
            {
                throw new BaseStationExeptions($"station {Id} dosen't exists ");
            }
            for (int i = 0; i < DataSource.stations.Count; i++)
            {
                if (DataSource.stations[i].Id == Id)
                {
                    s = DataSource.stations[i];

                }
            }
            return s;
        }
        Drone IDal.DisplayDrone(int Id)
        {
            Drone d = new Drone();
            if (DataSource.drones.Exists(drone => drone.Id != Id))
            {
                throw new DroneExeptions($"station {Id} dosen't exists ");
            }
            for (int i = 0; i < DataSource.drones.Count; i++)
            {
                if (DataSource.drones[i].Id == Id)
                {
                    d = DataSource.drones[i];


                }
            }
            return d;
        }

        //Displays customer by ID 
        Customer IDal.DisplayCustomer(int Id)
        {
            Customer c = new Customer();
            if (DataSource.customers.Exists(customer => customer.Id != Id))
            {
                throw new CustomerExeptions($"customer {Id} dosen't exists ");
            }
            for (int i = 0; i < DataSource.customers.Count; i++)
            {
                if (DataSource.customers[i].Id == Id)
                {
                    c = DataSource.customers[i];

                }
            }
            return c;
        }
        //Displays parcel by ID 
        Parcel IDal.DisplayParcel(int Id)
        {
            Parcel p = new Parcel();
            if (DataSource.parcels.Exists(parcel => parcel.Id != Id))
            {
                throw new ParcelExeptions($"parcel {Id} dosen't exists ");
            }
            for (int i = 0; i < DataSource.parcels.Count; i++)
            {
                if (DataSource.parcels[i].Id == Id)
                {
                    p = DataSource.parcels[i];

                }
            }
            return p;
        }
        //Displays a list of drone
        IEnumerable IDal.DisplayDroneList()
        {
            List<Drone> D = new List<Drone>();
            foreach (Drone d in DataSource.drones)
            {
                D.Add(d);
            }
            return D;
        }
        //Displays a list of base stations
        IEnumerable IDal.DisplayStationList()
        {
            List<BaseStation> S = new List<BaseStation>();
            foreach (BaseStation b in DataSource.stations)
            {
                S.Add(b);
            }
            return S;
        }
        //Displays a list of customer
        IEnumerable IDal.DisplayCustomerList()
        {
            List<Customer> C = new List<Customer>();
            foreach (Customer c in DataSource.customers)
            {
                C.Add(c);
            }
            return C;
        }
        //Displays a list of parcel
        IEnumerable IDal.DisplayParcelList()
        {
            List<Parcel> P = new List<Parcel>();
            foreach (Parcel p in DataSource.parcels)
            {
                P.Add(p);
            }
            return P;
        }
        //Displays a list of parcel not yet associated with the drone
        IEnumerable IDal.DisplayParcelUnmatched()
        {
            List<Parcel> P = new List<Parcel>();
            foreach (Parcel p in DataSource.parcels)
            {
                if (p.DroneId == 0)
                {
                    P.Add(p);
                }
            }
            return P;

        }
        //Displays base stations with available charging stations
        IEnumerable IDal.DisplayAvailableStation()
        {
            List<BaseStation> S = new List<BaseStation>();
            foreach (BaseStation b in DataSource.stations)
            {
                if (b.Longitude != 0)
                {
                    S.Add(b);
                }
                yield return S;
            }




        }
       double[] IDal.PowerConsumptionRequest()
        {
            double[] powerConsumtion = new double[] { DataSource.Config.Avaliable, DataSource.Config.Light, DataSource.Config.Medium, DataSource.Config.Heavy, DataSource.Config.ChargingRate };
            return powerConsumtion;
        }

    }
}


