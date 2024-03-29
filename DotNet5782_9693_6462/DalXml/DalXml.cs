﻿using DalApi;
using DO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.CompilerServices;


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
        string dronechargePath = @"DroneChargeXml.xml";
        #endregion

        #region Add methods
        //Add a parcel  to the list of  parcel
        void IDal.AddParcel(Parcel p)
        {
            XElement parcelelem = XMLTools.LoadListFromXMLElement(parcelPath);

            XElement parcel = (from par in parcelelem.Elements()
                               where int.Parse(par.Element("ID").Value) == p.Id
                               select par).FirstOrDefault();
            if (parcel != null)
            {
                throw new IDExistsInTheSystem(p.Id, $"Parcel ID Exists:{p.Id}");
            }

            XElement parcelElem = new XElement("Parcel", new XElement("ID", p.Id),
                                  new XElement("PickedUpTime", p.PickedUp),
                                  new XElement("DeliveredTime", p.Delivered),
                                  new XElement("ScheduledTime", p.Scheduled),
                                  new XElement("RequstedTime", p.Requsted),
                                  new XElement("SenderId", p.SenderId),
                                  new XElement("TargetId", p.TargetId),
                                  new XElement("Priorities", p.priority),
                                  new XElement("Parcelweight", p.weight),
                                  new XElement("DroneId", p.DroneId));

            parcelelem.Add(parcelElem);

            XMLTools.SaveListToXMLElement(parcelelem, parcelPath);
        }
        /// <summary>
        /// gets a customer from user and adds it 
        /// </summary>
        /// <param name="c"></param>
        void IDal.AddCustomer(Customer c)
        {
            XElement customerelem = XMLTools.LoadListFromXMLElement(customerPath);

            XElement customer = (from cos in customerelem.Elements()
                                 where int.Parse(cos.Element("ID").Value) == c.Id
                                 select cos).FirstOrDefault();
            if (customer != null)
            {
                throw new IDExistsInTheSystem(c.Id, $"Customer ID Exists:{c.Id}");
            }

            XElement customerElem = new XElement("Customer", new XElement("ID", c.Id),
                                  new XElement("Name", c.Name),
                                  new XElement("Phone", c.Phone),
                                  new XElement("Latitude", c.Latitude),
                                  new XElement("Longitude", c.Longitude));

            customerelem.Add(customerElem);

            XMLTools.SaveListToXMLElement(customerelem, customerPath);
        }

        //Add a base station to the list of stations
        void IDal.AddStation(BaseStation s)
        {
            XElement stationelem = XMLTools.LoadListFromXMLElement(basestationPath);

            XElement station = (from sta in stationelem.Elements()
                                where int.Parse(sta.Element("ID").Value) == s.Id
                                select sta).FirstOrDefault();
            if (station != null)
            {
                throw new IDExistsInTheSystem(s.Id, $"Basestation ID Exists:{s.Id}");
            }

            XElement stationElem = new XElement("BaseStation", new XElement("ID", s.Id),
                                  new XElement("Name", s.Name),
                                  new XElement("ChargeSlots", s.ChargeSlots),
                                  new XElement("Latitude", s.Latitude),
                                  new XElement("Longitude", s.Longitude));

            stationelem.Add(stationElem);

            XMLTools.SaveListToXMLElement(stationelem, basestationPath);
        }
        // Add a drone  to the list of  drones
        void IDal.AddDrone(Drone d)
        {
            XElement droneelem = XMLTools.LoadListFromXMLElement(dronePath);

            XElement drone = (from dr in droneelem.Elements()
                              where int.Parse(dr.Element("Id").Value) == d.Id
                              select dr).FirstOrDefault();
            if (drone != null)
            {
                throw new IDExistsInTheSystem(d.Id, $"Drone ID Exists:{d.Id}");
            }

            XElement droneElem = new XElement("Drone", new XElement("Id", d.Id),
                                  new XElement("Model", d.Model),
                                  new XElement("MaxWeight", d.MaxWeight));

            droneelem.Add(droneElem);

            XMLTools.SaveListToXMLElement(droneelem, dronePath);
        }
        /// <summary>
        /// adds a new drone in charging
        /// </summary>
        /// <param name="dr"></param>
        public void AddDronetocharge(DroneCharge dr)
        {
            XElement dronechargeelem = XMLTools.LoadListFromXMLElement(dronechargePath);

            XElement dronech = (from drch in dronechargeelem.Elements()
                                where int.Parse(drch.Element("DroneId").Value) == dr.DroneId
                                select drch).FirstOrDefault();
            if (dronech != null)
            {
                throw new IDExistsInTheSystem(dr.DroneId, $"Drone ID Exists:{dr.DroneId}");
            }
            XElement drchelem = new XElement("DroneCharge", new XElement("DroneId", dr.DroneId),
                new XElement("StationId", dr.StatioId),
                new XElement("StartCharge", dr.startcharge));
            dronechargeelem.Add(drchelem);
            XMLTools.SaveListToXMLElement(dronechargeelem, dronechargePath);
        }
        #endregion

        #region update methods
        /// <summary>
        /// updates drone model
        /// </summary>
        /// <param name="d"></param>
        void IDal.UpdateDrone(Drone d)
        {
            XElement droneelem = XMLTools.LoadListFromXMLElement(dronePath);

            XElement drone = (from dr in droneelem.Elements()
                              where int.Parse(dr.Element("Id").Value) == d.Id
                              select dr).FirstOrDefault();
            drone.Element("Model").Value = d.Model;
            XMLTools.SaveListToXMLElement(droneelem, dronePath);
        }
        /// <summary>
        /// updates base stations name and charge slotes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="chargeslots"></param>
        void IDal.UpdateBaseStation(int id, int name, int chargeslots)
        {
            XElement stationelem = XMLTools.LoadListFromXMLElement(basestationPath);
            XElement sta = (from d in stationelem.Elements()
                            where int.Parse(d.Element("ID").Value) == id
                            select d).FirstOrDefault();
            if (sta != null)
            {
                if (name != null)
                {
                    sta.Element("Name").Value = name.ToString();
                }
                if (chargeslots != null)
                {
                    sta.Element("Chargeslots").Value = chargeslots.ToString();
                }
                XMLTools.SaveListToXMLElement(stationelem, basestationPath);
            }
            else { throw new IDNotExistsInTheSystem(id, $"Basestation ID dosn't Exist:{id}"); }
        }

        /// <summary>
        /// updates customers name and phone
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        void IDal.UpdateCustomer(int id, String name, String phone)
        {
            XElement customerelem = XMLTools.LoadListFromXMLElement(customerPath);
            XElement cust = (from c in customerelem.Elements()
                             where int.Parse(c.Element("ID").Value) == id
                             select c).FirstOrDefault();
            if (cust != null)
            {
                if (name != null)
                {
                    cust.Element("Name").Value = name;
                }
                if (phone != null)
                {
                    cust.Element("Phone").Value = phone;
                }
                XMLTools.SaveListToXMLElement(customerelem, customerPath);
            }
            else
            {
                throw new IDNotExistsInTheSystem(id, $"Customer ID dosn't Exist:{id}");
            }
        }
        //connects parcel  to a drone
        void IDal.UpdateParcelToDrone(int droneId, int parcleId)
        {
            XElement droneselem = XMLTools.LoadListFromXMLElement(dronePath);
            XElement dr = (from d in droneselem.Elements()
                           where int.Parse(d.Element("Id").Value) == droneId
                           select d).FirstOrDefault();
            XElement parcelelem = XMLTools.LoadListFromXMLElement(parcelPath);
            XElement par = (from p in parcelelem.Elements()
                            where int.Parse(p.Element("ID").Value) == parcleId
                            select p).FirstOrDefault();

            if (dr == null)
            {
                throw new IDNotExistsInTheSystem(droneId, $"Drone ID dosn't Exist:{droneId}");
            }
            if (par == null)
            {
                throw new IDNotExistsInTheSystem(parcleId, $"Drone ID dosn't Exist:{parcleId}");
            }

            par.Element("DroneId").Value = droneId.ToString();
            par.Element("ScheduledTime").Value = DateTime.Now.ToString();
            XMLTools.SaveListToXMLElement(parcelelem, parcelPath);
        }
        /// <summary>
        /// updates parcels target and priority
        /// </summary>
        /// <param name="p"></param>
        void IDal.UpdateParcel(Parcel p)
        {
            XElement parcelelem = XMLTools.LoadListFromXMLElement(parcelPath);

            XElement parcel = (from par in parcelelem.Elements()
                               where int.Parse(par.Element("ID").Value) == p.Id
                               select par).FirstOrDefault();
            if (parcel == null)
            {
                throw new IDExistsInTheSystem(p.Id, $"Parcel ID Exists:{p.Id}");
            }
            if (p.TargetId != -1)
            {
                parcel.Element("TargetId").Value = p.TargetId.ToString();
            }
            if (p.priority != null)
            {
                parcel.Element("Priorities").Value = p.priority.ToString();
            }
            XMLTools.SaveListToXMLElement(parcelelem, parcelPath);
        }
        #endregion

        #region Parcel system methods

        //Parcel collection by drone
        void IDal.Parcelcollection(int pd, int dId)
        {

            XElement droneselem = XMLTools.LoadListFromXMLElement(dronePath);
            XElement dr = (from d in droneselem.Elements()
                           where int.Parse(d.Element("ID").Value) == dId
                           select d).FirstOrDefault();
            XElement parcelelem = XMLTools.LoadListFromXMLElement(parcelPath);
            XElement par = (from p in parcelelem.Elements()
                            where int.Parse(p.Element("ID").Value) == pd
                            select p).FirstOrDefault();

            if (dr == null)
            {
                throw new IDNotExistsInTheSystem(dId, $"Drone ID dosn't Exist:{dId}");
            }
            if (par == null)
            {
                throw new IDNotExistsInTheSystem(pd, $"Parcel ID dosn't Exist:{pd}");
            }
            par.Element("DroneId").Value = dId.ToString();
            par.Element("PickedUp").Value = DateTime.Now.ToString();
            XMLTools.SaveListToXMLElement(parcelelem, parcelPath);
        }

        //Delivery of a parcel to the customer
        void IDal.ParcelDelivery(int pId, int cId)
        {
            XElement customerelem = XMLTools.LoadListFromXMLElement(customerPath);
            XElement cust = (from c in customerelem.Elements()
                             where int.Parse(c.Element("ID").Value) == cId
                             select c).FirstOrDefault();
            XElement parcelelem = XMLTools.LoadListFromXMLElement(parcelPath);
            XElement par = (from p in parcelelem.Elements()
                            where int.Parse(p.Element("ID").Value) == pId
                            select p).FirstOrDefault();
            if (par == null)
            {
                throw new IDNotExistsInTheSystem(pId, $"Parcel ID dosn't Exist:{pId}");
            }
            if (cust == null)
            {
                throw new IDNotExistsInTheSystem(cId, $"Customer ID dosn't Exist:{cId}");
            }
            //par.Element("SenderId").Value = cId.ToString();
            par.Element("TargetId").Value = cId.ToString();
            par.Element("Delivered").Value = DateTime.Now.ToString();
            XMLTools.SaveListToXMLElement(parcelelem, parcelPath);
        }

        //Sending drone for charging at a base station
        void IDal.ChargeDrone(int droneId, int sId)
        {
            XElement droneselem = XMLTools.LoadListFromXMLElement(dronePath);
            XElement dr = (from d in droneselem.Elements()
                           where int.Parse(d.Element("Id").Value) == droneId
                           select d).FirstOrDefault();
            XElement stationelem = XMLTools.LoadListFromXMLElement(basestationPath);

            XElement sta = (from d in stationelem.Elements()
                            where int.Parse(d.Element("Id").Value) == sId
                            select d).FirstOrDefault();

            XElement drchelem = XMLTools.LoadListFromXMLElement(dronechargePath);
            XElement dch = (from d in drchelem.Elements()
                            where int.Parse(d.Element("DroneId").Value) == droneId
                            select d).FirstOrDefault();
            if (dr == null)
            {
                throw new IDNotExistsInTheSystem(droneId, $"Drone ID dosn't Exist:{droneId}");
            }
            if (sta == null)
            {
                throw new IDNotExistsInTheSystem((int)sId, $"Basestation ID dosn't Exist:{sId}");
            }
            if (dch != null)
            {
                throw new IDExistsInTheSystem(droneId, $"Drone ID Exist in charge list:{droneId}");
            }
            DroneCharge drch = new DroneCharge
            {
                DroneId = droneId,
                StatioId = sId,
                startcharge = DateTime.Now
            };
            AddDronetocharge(drch);
            XMLTools.SaveListToXMLElement(stationelem, basestationPath);
        }

        //Discharge drone from charging at base station
        void IDal.DischargeDrone(int Id)
        {
            XElement dronechargeelem = XMLTools.LoadListFromXMLElement(dronechargePath);
            XElement drch = (from d in dronechargeelem.Elements()
                             where int.Parse(d.Element("DroneId").Value) == Id
                             select d).FirstOrDefault();

            XElement droneselem = XMLTools.LoadListFromXMLElement(dronePath);
            XElement dr = (from d in droneselem.Elements()
                           where int.Parse(d.Element("Id").Value) == Id
                           select d).FirstOrDefault();
            XElement stationelem = XMLTools.LoadListFromXMLElement(basestationPath);
            XElement sta = (from d in stationelem.Elements()
                            where int.Parse(d.Element("Id").Value) == int.Parse(drch.Element("StationId").Value)
                            select d).FirstOrDefault();
            if (drch == null)
            {
                throw new IDNotExistsInTheSystem(Id, $"Drone ID dosn't Exist:{Id}");
            }
            drch.Remove();
            XMLTools.SaveListToXMLElement(dronechargeelem, dronechargePath);
            XMLTools.SaveListToXMLElement(droneselem, dronePath);
            XMLTools.SaveListToXMLElement(stationelem, basestationPath);
        }
        #endregion

        #region get items
        //displays station by id
        BaseStation IDal.DisplayStation(int Id)
        {
            XElement stationelem = XMLTools.LoadListFromXMLElement(basestationPath);
            BaseStation s = ((BaseStation)(from stat in stationelem.Elements()
                                           where int.Parse(stat.Element("Id").Value) == Id
                                           select new BaseStation()
                                           {
                                               Id = Int32.Parse(stat.Element("Id").Value),
                                               ChargeSlots = Int32.Parse(stat.Element("ChargeSlots").Value),
                                               Name = Int32.Parse(stat.Element("Name").Value),
                                               Longitude = double.Parse((string)stat.Element("Longitude")),
                                               Latitude = double.Parse((string)stat.Element("Latitude"))
                                           }).FirstOrDefault());

            if (s == null)
            {

            }
            return s;
        }
        Drone IDal.DisplayDrone(int Id)
        {
            XElement droneelem = XMLTools.LoadListFromXMLElement(dronePath);
            Drone d = ((Drone)(from dr in droneelem.Elements()
                               where int.Parse(dr.Element("Id").Value) == Id
                               select new Drone()
                               {
                                   Id = Int32.Parse(dr.Element("Id").Value),
                                   Model = dr.Element("Modle").Value,
                                   MaxWeight = (Weights)Enum.Parse(typeof(Weights), dr.Element("MaxWeight").Value)
                               }).FirstOrDefault());

            if (d == null)
            {

            }
            return d;
        }

        /// <summary>
        /// gets drone charging by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DroneCharge DisplayDroneCharge(int id)
        {
            XElement dronechelem = XMLTools.LoadListFromXMLElement(dronechargePath);
            DroneCharge d = ((from dr in dronechelem.Elements()
                              where int.Parse(dr.Element("DroneId").Value) == id
                              select new DroneCharge()
                              {
                                  DroneId = Int32.Parse(dr.Element("DroneId").Value),
                                  StatioId = Int32.Parse(dr.Element("StationId").Value),
                                  startcharge = DateTime.Parse(dr.Element("StartCharge").Value)
                              }).FirstOrDefault());
            return d;
        }

        //Displays customer by ID 
        Customer IDal.DisplayCustomer(int Id)
        {
            XElement customerelem = XMLTools.LoadListFromXMLElement(customerPath);
            Customer c = (from cust in customerelem.Elements()
                          where int.Parse(cust.Element("ID").Value) == Id
                          select new Customer
                          {
                              Id = Int32.Parse(cust.Element("ID").Value),
                              Name = cust.Element("Name").Value,
                              Phone = cust.Element("Phone").Value,
                              Longitude = double.Parse(cust.Element("Longitude").Value),
                              Latitude = double.Parse(cust.Element("Latitude").Value)
                          }).FirstOrDefault();

            if (c == null)
            {

            }
            return c;
        }
        //Displays parcel by ID 
        Parcel IDal.DisplayParcel(int Id)
        {
            XElement parcelelem = XMLTools.LoadListFromXMLElement(parcelPath);
            Parcel p = new Parcel();
            p = (from par in parcelelem.Elements()
                 where int.Parse(par.Element("ID").Value) == Id
                 select new Parcel
                 {
                     Id = Int32.Parse(par.Element("ID").Value),
                     DroneId = Int32.Parse(par.Element("DroneId").Value),
                     Delivered = DateTime.Parse(par.Element("DeliveredTime").Value),
                     Scheduled = DateTime.Parse(par.Element("ScheduledTime").Value),
                     PickedUp = DateTime.Parse(par.Element("PickedUpTime").Value),
                     Requsted = DateTime.Parse(par.Element("RequstedTime").Value),
                     priority = (Priorities)Enum.Parse(typeof(Priorities), par.Element("Priorities").Value),
                     SenderId = Int32.Parse(par.Element("SenderId").Value),
                     TargetId = Int32.Parse(par.Element("TargetId").Value),
                     weight = (Weights)Enum.Parse(typeof(Weights), par.Element("Parcelweight").Value)
                 }).FirstOrDefault();

            if (p == null)
            {

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
                        Id = Int32.Parse(d.Element("Id").Value),
                        Model = d.Element("Model").Value,
                        MaxWeight = (Weights)Enum.Parse(typeof(Weights), d.Element("MaxWeight").Value)
                    }).ToList();

        }
        //Displays a list of base stations
        IEnumerable IDal.DisplayStationList(Func<BaseStation, bool> prd)
        {
            XElement stationelemnts = XMLTools.LoadListFromXMLElement(basestationPath);
            return (from stat in stationelemnts.Elements()
                    select new BaseStation()
                    {
                        Id = Int32.Parse(stat.Element("Id").Value),
                        ChargeSlots = Int32.Parse(stat.Element("ChargeSlots").Value),
                        Name = Int32.Parse(stat.Element("Name").Value),
                        Longitude = double.Parse((string)stat.Element("Longitude")),
                        Latitude = double.Parse((string)stat.Element("Latitude"))
                    }).ToList();
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
        //Displays a list of parcel with filter and without
        IEnumerable IDal.DisplayParcelList(Func<Parcel, bool> p)
        {
            XElement parcelelemnts = XMLTools.LoadListFromXMLElement(parcelPath);
            if (p != null)
            {
                return (from par in parcelelemnts.Elements()
                        let P = new Parcel()
                        {
                            Id = Int32.Parse(par.Element("ID").Value),
                            DroneId = Int32.Parse(par.Element("DroneId").Value),
                            Delivered = DateTime.Parse(par.Element("DeliveredTime").Value),
                            Scheduled = DateTime.Parse(par.Element("ScheduledTime").Value),
                            PickedUp = DateTime.Parse(par.Element("PickedUpTime").Value),
                            Requsted = DateTime.Parse(par.Element("RequstedTime").Value),
                            priority = (Priorities)Enum.Parse(typeof(Priorities), par.Element("Priorities").Value),
                            SenderId = Int32.Parse(par.Element("SenderId").Value),
                            TargetId = Int32.Parse(par.Element("TargetId").Value),
                            weight = (Weights)Enum.Parse(typeof(Weights), par.Element("Parcelweight").Value)
                        }
                        where p(P)
                        select P);
            }
            else
            {
                return (from par in parcelelemnts.Elements()
                        select new Parcel()
                        {
                            Id = Int32.Parse(par.Element("ID").Value),
                            DroneId = Int32.Parse(par.Element("DroneId").Value),
                            Delivered = DateTime.Parse(par.Element("DeliveredTime").Value),
                            Scheduled = DateTime.Parse(par.Element("ScheduledTime").Value),
                            PickedUp = DateTime.Parse(par.Element("PickedUpTime").Value),
                            Requsted = DateTime.Parse(par.Element("RequstedTime").Value),
                            priority = (Priorities)Enum.Parse(typeof(Priorities), par.Element("Priorities").Value),
                            SenderId = Int32.Parse(par.Element("SenderId").Value),
                            TargetId = Int32.Parse(par.Element("TargetId").Value),
                            weight = (Weights)Enum.Parse(typeof(Weights), par.Element("Parcelweight").Value)
                        });

            }
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
                       priority = (Priorities)Enum.Parse(typeof(Priorities), par.Element("Priorities").Value),
                       SenderId = Int32.Parse(par.Element("SenderId").Value),
                       TargetId = Int32.Parse(par.Element("TargetId").Value),
                       weight = (Weights)Enum.Parse(typeof(Weights), par.Element("ParcelWeight").Value)
                   }
                   where predicate(p)
                   select p;
        }
        /// <summary>
        /// diaplays all the stations with aviable charging slots
        /// </summary>
        /// <param name="drch"></param>
        /// <returns></returns>
        private IEnumerable<DroneCharge> DisplayDroneToChargelst(Predicate<DroneCharge> drch = null)
        {
            XElement parcelelemnts = XMLTools.LoadListFromXMLElement(dronechargePath);
            if (drch != null)
            {
                return (from dr in parcelelemnts.Elements()
                        let D = new DroneCharge()
                        {
                            DroneId = Int32.Parse(dr.Element("DroneId").Value),
                            StatioId = Int32.Parse(dr.Element("StationId").Value),
                            startcharge = DateTime.Parse(dr.Element("StartCharge").Value)
                        }
                        where drch(D)
                        select D);
            }
            return null;
        }
        //Displays base stations with available charging stations
        IEnumerable IDal.DisplayAvailableStation(Predicate<DO.BaseStation> b = null)
        {
            List<BaseStation> B = new List<BaseStation>();
            List<DroneCharge> d = new List<DroneCharge>();
            foreach (BaseStation bs in DisplayStationLst())
            {
                foreach (DroneCharge dc in DisplayDroneToChargelst(x => x.StatioId == bs.Id))
                {
                    d.Add(dc);
                }
                if (bs.ChargeSlots - d.Count >= 0)
                {
                    B.Add(bs);
                }
                d.Clear();
            }
            return B;
        }
        /// <summary>
        /// to get basestation list to use only hear
        /// </summary>
        /// <returns></returns>
        private IEnumerable<BaseStation> DisplayStationLst()
        {
            XElement stationelemnts = XMLTools.LoadListFromXMLElement(basestationPath);
            return (from stat in stationelemnts.Elements()
                    select new BaseStation()
                    {
                        Id = Int32.Parse(stat.Element("Id").Value),
                        ChargeSlots = Int32.Parse(stat.Element("ChargeSlots").Value),
                        Name = Int32.Parse(stat.Element("Name").Value),
                        Longitude = double.Parse((string)stat.Element("Longitude")),
                        Latitude = double.Parse((string)stat.Element("Latitude"))
                    }).ToList();
        }


        #endregion
    }

}
