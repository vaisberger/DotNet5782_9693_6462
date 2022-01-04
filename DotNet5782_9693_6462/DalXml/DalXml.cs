using DalApi;
using DO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    sealed class DalXml : IDal
    {
        #region constructers
        static readonly DalXml instance = new DalXml();
        static DalXml() { }
        DalXml() { }
        public static DalXml Instance { get => instance; }

        string dronePath = @"DroneXml.xml";
        string basestationPath = @"BaseStationXml.xml";
        string customerPath = @"CustomerXml.xml";
        string parcelPath = @"ParcelXml.xml";
        #endregion

        #region Add methods
        //Add a parcel  to the list of  parcel
         void AddParcel(Parcel p)
        {
            XElement parcelelem = XMLTools.LoadListFromXMLElement(parcelPath);

            XElement parcel = (from par in parcelelem.Elements()
                             where int.Parse(par.Element("ID").Value) == p.Id
                             select par).FirstOrDefault();
            if (parcel != null)
            {
                throw
            }

            XElement parcelElem = new XElement("Person", new XElement("ID", p.Id),
                                  new XElement("PickedUpTime", p.PickedUp),
                                  new XElement("DeliveredTime", p.Delivered),
                                  new XElement("ScheduledTime", p.Scheduled),
                                  new XElement("RequstedTime", p.Requsted),
                                  new XElement("SenderId", p.SenderId),
                                  new XElement("TargetId", p.TargetId),
                                  new XElement("priorty", p.priorty),
                                  new XElement("weight", p.weight),
                                  new XElement("DroneId", p.DroneId));

            parcelelem.Add(parcelElem);

            XMLTools.SaveListToXMLElement(parcelelem, parcelPath);
        }
        //Add customer to the list of customer
        void IDal.AddCustomer(Customer c)
        {
            XElement customerelem = XMLTools.LoadListFromXMLElement(customerPath);

            XElement customer = (from par in customerelem.Elements()
                               where int.Parse(par.Element("ID").Value) == c.Id
                               select par).FirstOrDefault();
            if (customer != null)
            {
                throw
            }

            XElement customerElem = new XElement("Person", new XElement("ID", p.Id),
                                  new XElement("PickedUpTime", par.PickedUp),
                                  new XElement("DeliveredTime", p.Delivered),
                                  new XElement("ScheduledTime", p.Scheduled),
                                  new XElement("RequstedTime", p.Requsted),
                                  new XElement("SenderId", p.SenderId),
                                  new XElement("TargetId", p.TargetId),
                                  new XElement("priorty", p.priorty),
                                  new XElement("weight", p.weight),
                                  new XElement("DroneId", p.DroneId));

            customerelem.Add(customerElem);

            XMLTools.SaveListToXMLElement(customerelem, customerPath);
        }

        //Add a base station to the list of stations
        void IDal.AddStation(BaseStation s)
        {

        }
        // Add a drone  to the list of  drones
        void IDal.AddDrone(Drone d)
        {

        }
        #endregion

        #region update methods
        void IDal.UpdateDrone(int id, String model)
        {
            var d = DataSource.drones.FirstOrDefault(X => X.Id == id);
            d.Model = model;
        }
        void IDal.UpdateBaseStation(int id, int name, int chargeslots)
        {
            var s = DataSource.stations.FirstOrDefault(bs => bs.Id == id);
            if (name != -1)
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
            Drone d = DataSource.drones.FirstOrDefault(drone => drone.Id != droneId);
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
        #endregion

        #region Parcel system methods
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
            DroneCharge dcs = DataSource.droneCharges.FirstOrDefault(x => x.DroneId == d);
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
        #endregion
        // עשיתי
        #region get items
        ////Drone display by ID
        BaseStation IDal.DisplayStation(int Id)
        {
            XElement stationelem = XMLTools.LoadListFromXMLElement(basestationPath);
            BaseStation s = ((BaseStation)(from stat in stationelem.Elements()
                                           where int.Parse(stat.Element("ID").Value) == Id
                                           select new BaseStation()
                                           {
                                               Id = Int32.Parse(stat.Element("ID").Value),
                                               ChargeSlots = Int32.Parse(stat.Element("Slots").Value),
                                               Name = Int32.Parse(stat.Element("Name").Value),
                                               Longitude = double.Parse((string)stat.Element("Longitude")),
                                               Latitude = double.Parse((string)stat.Element("Latitude"))
                                           }).FirstOrDefault());

            if (s==null)
            {
                throw new DO.idnotfound();
            }
            return s;
        }
        Drone IDal.DisplayDrone(int Id)
        {
            XElement droneelem = XMLTools.LoadListFromXMLElement(dronePath);
            Drone d = ((Drone)(from dr in droneelem.Elements()
                                           where int.Parse(dr.Element("ID").Value) == Id
                                           select new Drone()
                                           {
                                               Id = Int32.Parse(dr.Element("ID").Value),
                                               Model = dr.Element("Modle").Value,
                                               droneCharge = (DroneCharge)Enum.Parse(typeof(DroneCharge), dr.Element("ChargeStatus").Value),
                                               MaxWeight = (Weights)Enum.Parse(typeof(Weights), dr.Element("WeightStatus").Value)
                                           }).FirstOrDefault());

            if (d == null)
            {
                throw new DO.idnotfound();
            }
            return d;
        }

        //Displays customer by ID 
        Customer IDal.DisplayCustomer(int Id)
        {
            XElement customerelem = XMLTools.LoadListFromXMLElement(customerPath);
            Customer c = ((Customer)(from cust in customerelem.Elements()
                               where int.Parse(cust.Element("ID").Value) == Id
                               select new Customer()
                               {
                                   Id = Int32.Parse(cust.Element("ID").Value),
                                   Name = cust.Element("Name").Value,
                                   Phone= cust.Element("Phone").Value,
                                   Longitude = double.Parse((string)cust.Element("Longitude")),
                                   Latitude = double.Parse((string)cust.Element("Latitude"))
                               }).FirstOrDefault());

            if (c == null)
            {
                throw new DO.idnotfound();
            }
            return c;
        }
        //Displays parcel by ID 
        Parcel IDal.DisplayParcel(int Id)
        {
            XElement parcelelem = XMLTools.LoadListFromXMLElement(parcelPath);
            Parcel p = ((Parcel)(from par in parcelelem.Elements()
                                     where int.Parse(par.Element("ID").Value) == Id
                                     select new Parcel()
                                     {
                                         Id = Int32.Parse(par.Element("ID").Value),
                                         DroneId = Int32.Parse(par.Element("DroneId").Value),
                                         Delivered = DateTime.Parse(par.Element("DeliverdTime").Value),
                                         Scheduled= DateTime.Parse(par.Element("ScheduledTime").Value),
                                         PickedUp= DateTime.Parse(par.Element("PickedUpTime").Value),
                                         Requsted= DateTime.Parse(par.Element("RequstedTime").Value),
                                         priorty= (Priorities)Enum.Parse(typeof(Priorities), par.Element("Priorities").Value),
                                         SenderId = Int32.Parse(par.Element("SenderId").Value),
                                         TargetId = Int32.Parse(par.Element("TargetId").Value),
                                         weight= (Weights)Enum.Parse(typeof(Weights), par.Element("ParcelWeight").Value)
                                     }).FirstOrDefault());

            if (p == null)
            {
                throw new DO.idnotfound();
            }
            return p;
        }

        #endregion

        #region display list methods

        //Displays a list of drone
        IEnumerable IDal.DisplayDroneList()
        {
            XElement droneelemnts = XMLTools.LoadListFromXMLElement(dronePath);
            return (from d in droneelemnts.Elements()
                    select new Drone()
                    {
                        Id = Int32.Parse(d.Element("ID").Value),
                        Model = d.Element("Modle").Value,
                        droneCharge = (DroneCharge)Enum.Parse(typeof(DroneCharge), d.Element("ChargeStatus").Value),
                        MaxWeight = (Weights)Enum.Parse(typeof(Weights), d.Element("WeightStatus").Value)
                    });

        }
        //Displays a list of base stations
        IEnumerable IDal.DisplayStationList()
        {
            XElement stationelemnts = XMLTools.LoadListFromXMLElement(basestationPath);
            return (from stat in stationelemnts.Elements()
                    select new BaseStation()
                    {
                        Id = Int32.Parse(stat.Element("ID").Value),
                        ChargeSlots = Int32.Parse(stat.Element("Slots").Value),
                        Name = Int32.Parse(stat.Element("Name").Value),
                        Longitude = double.Parse((string)stat.Element("Longitude")),
                        Latitude = double.Parse((string)stat.Element("Latitude"))
                    });
        }
        //Displays a list of customer
        IEnumerable IDal.DisplayCustomerList()
        {
            XElement customerelemnts = XMLTools.LoadListFromXMLElement(customerPath);
            return (from cust in customerelemnts.Elements()
                    select new Customer()
                    {
                        Id = Int32.Parse(cust.Element("ID").Value),
                        Name = cust.Element("Name").Value,
                        Phone = cust.Element("Phone").Value,
                        Longitude = double.Parse((string)cust.Element("Longitude")),
                        Latitude = double.Parse((string)cust.Element("Latitude"))
                    });
        }
        //Displays a list of parcel
        IEnumerable IDal.DisplayParcelList()
        {
            XElement parcelelemnts = XMLTools.LoadListFromXMLElement(parcelPath);
            return (from par in parcelelemnts.Elements()
                    select new Parcel()
                    {
                        Id = Int32.Parse(par.Element("ID").Value),
                        DroneId = Int32.Parse(par.Element("DroneId").Value),
                        Delivered = DateTime.Parse(par.Element("DeliverdTime").Value),
                        Scheduled = DateTime.Parse(par.Element("ScheduledTime").Value),
                        PickedUp = DateTime.Parse(par.Element("PickedUpTime").Value),
                        Requsted = DateTime.Parse(par.Element("RequstedTime").Value),
                        priorty = (Priorities)Enum.Parse(typeof(Priorities), par.Element("Priorities").Value),
                        SenderId = Int32.Parse(par.Element("SenderId").Value),
                        TargetId = Int32.Parse(par.Element("TargetId").Value),
                        weight = (Weights)Enum.Parse(typeof(Weights), par.Element("ParcelWeight").Value)
                    });
        }
        //Displays a list of parcel not yet associated with the drone
        IEnumerable IDal.DisplayParcelUnmatched(Predicate<Parcel> predicate)
        {
            XElement parcelelemnts = XMLTools.LoadListFromXMLElement(parcelPath);
            return from par in parcelelemnts.Elements()
                   let p = new Parcel()
                   {
                       Id = Int32.Parse(par.Element("ID").Value),
                       DroneId = Int32.Parse(par.Element("DroneId").Value),
                       Delivered = DateTime.Parse(par.Element("DeliverdTime").Value),
                       Scheduled = DateTime.Parse(par.Element("ScheduledTime").Value),
                       PickedUp = DateTime.Parse(par.Element("PickedUpTime").Value),
                       Requsted = DateTime.Parse(par.Element("RequstedTime").Value),
                       priorty = (Priorities)Enum.Parse(typeof(Priorities), par.Element("Priorities").Value),
                       SenderId = Int32.Parse(par.Element("SenderId").Value),
                       TargetId = Int32.Parse(par.Element("TargetId").Value),
                       weight = (Weights)Enum.Parse(typeof(Weights), par.Element("ParcelWeight").Value)
                   }
                   where predicate(p)
                   select p;
        }
        //Displays base stations with available charging stations
        IEnumerable IDal.DisplayAvailableStation(Predicate<BaseStation> predicate)
        {
            XElement stationelemnts = XMLTools.LoadListFromXMLElement(basestationPath);
            return from stat in stationelemnts.Elements()
                   let s = new BaseStation()
                   {
                       Id = Int32.Parse(stat.Element("ID").Value),
                       ChargeSlots = Int32.Parse(stat.Element("Slots").Value),
                       Name = Int32.Parse(stat.Element("Name").Value),
                       Longitude = double.Parse((string)stat.Element("Longitude")),
                       Latitude = double.Parse((string)stat.Element("Latitude"))
                   }
                   where predicate(s)
                   select s;
        }
        #endregion
        double[] IDal.PowerConsumptionRequest()
        {
            double[] powerConsumtion = new double[] { DataSource.Config.Avaliable, DataSource.Config.Light, DataSource.Config.Medium, DataSource.Config.Heavy, DataSource.Config.ChargingRate };
            return powerConsumtion;
        }

    }

}
