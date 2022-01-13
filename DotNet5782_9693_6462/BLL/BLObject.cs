using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BO;
using DalApi;
using BLApi;
using DO;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using BO;

public interface IEnumerable<out list> : IEnumerable
{
    IEnumerable<list> GetEnumerable();
}
namespace BLObject
{
     public sealed class BLObject:IBl
    {
        static readonly IBl instance = new BLObject();
        public static IBl Instance{ get=> instance; } 

        public ObservableCollection<BO.Drone> drones;
        internal IDal mydale=DalFactory.GetDal();

        public BLObject() // היה פריווט והחלפנו לפבליק כדי שיעבוד
        {
            drones = new ObservableCollection<BO.Drone>();
        }

        public void AddCustomer(BO.Customer customer)
        {

            DO.Customer customer1 = new DO.Customer();
            customer1.Id = customer.Id;
            customer1.Name = customer.Name;
            customer1.Phone = customer.Phone;
            customer1.Latitude = customer.location.Latitude;
            customer1.Longitude = customer.location.Longitude;
            mydale.AddCustomer(customer1);
        }

        public void AddDrone(BO.Drone drone)
        {
            try
            {
                BO.Drone d = drones.FirstOrDefault(x => x.Id == drone.Id);
                if (d != null)
                {
                    throw new DO.IDNotExistsInTheSystem(drone.Id);
                }
            }
            catch (DO.IDExistsInTheSystem ex)
            {
                throw new BO.DroneExistsException($"Cant add the drone: {drone.Id} because the Id allready exists in the system", ex);
            }
            Random r = new Random();
            DO.Drone drone1 = new DO.Drone();
            drone1.Id = drone.Id;
            drone1.Model = drone.Model;
            drone1.MaxWeight = (DO.Weights)drone.MaxWeight;
            drone.Battery = r.Next(20, 41);
            drones.Add(drone);
           // mydale.AddDrone(drone1);

        }
        public void AddParcel(BO.Parcel parcel)
        {
            DO.Parcel parcel1 = new DO.Parcel();
            parcel1.SenderId = parcel.Sender.Id;
            parcel1.TargetId = parcel.Getting.Id;
            parcel1.weight = (DO.Weights)parcel.weight;
            parcel1.priorty = (DO.Priorities)parcel.priority;
            parcel1.Requsted = parcel.Requsted;
            parcel1.DroneId = parcel.droaneParcel.Id;
            parcel1.PickedUp = parcel.PickedUp;
            parcel1.Scheduled = parcel.Scheduled;
            parcel1.Delivered = parcel.Delivered;
            mydale.AddParcel(parcel1);
        }

        public void AddBaseStation(BO.BaseStation baseStation)          // לא נכון צריך תיקון
        {
            DO.BaseStation baseStation1 = new DO.BaseStation();
            baseStation1.Id = baseStation.Id;
            baseStation1.Name = baseStation.Name;
            baseStation1.Latitude = baseStation.location.Latitude;
            baseStation1.Longitude = baseStation.location.Longitude;
            baseStation1.ChargeSlots = baseStation.AvailableChargingStations;
            baseStation.DroneInChargings = baseStation.DroneInChargings;
        }

       /* public void UpdateDrone(int id, string s)
        {
            throw new NotImplementedException();
        }*/

        public BO.Customer GetCustomer(int id)
        {
            BO.Customer customer = default;
            try
            {
                DO.Customer dalCustomper = mydale.DisplayCustomer(id);
            }
            catch (DO.CustomerExeptions custEx)
            {
                throw new BLParcelExption($"Customer id {id} was not found", custEx);
            }

            return customer;
        }


        public BO.Drone GetDrone(int id)
        {
            BO.Drone d = drones.FirstOrDefault(x => x.Id == id);

            if (d==null)
            {
                throw new BLDroneExption($"drone {id} was not found");
            }
            return d;
        }
        public BO.Parcel GetParcel(int id)
        {
            BO.Parcel parcel= default;
            try
            {
                DO.Parcel dalParcel = mydale.DisplayParcel(id);
            }
            catch (DO.ParcelExeptions custEx)
            {
                throw new BLParcelExption($"Parcel id {id} was not found", custEx);
            }

            return parcel;
        }



        public BO.BaseStation GetBaseStation(int id)
        {
            BO.BaseStation baseStation = default;
            try
            {
                DO.BaseStation dalBaseStation = mydale.DisplayStation(id);
            }
            catch (DO.BaseStationExeptions custEx)
            {
                throw new BLBaseStationExption($"BaseStation id {id} was not found", custEx);
            }

            return baseStation;
        }


        public void UpdateDrone(int id, String model)
        {

            try
            {
                mydale.DisplayDrone(id);
            }
            catch (DO.DroneExeptions dexp)
            {
                throw new BLDroneExption($"Can't update the drone because it dosn't exist");
            }

            mydale.UpdateDrone(id, model);
        }

        public void UpdateBaseStation(int id, int name = -1, int chargeslots = -1)
        {
            try
            {
                mydale.DisplayStation(id);
            }
            catch (DO.BaseStationExeptions bexp)
            {
                throw new BLBaseStationExption($"Can't update the station because it dosn't exist");
            }
            mydale.UpdateBaseStation(id, name, chargeslots);
        }


        public void UpdateCustomer(int id, String name = "", String phone = "")
        {
            try
            {
                mydale.DisplayCustomer(id);
            }
            catch (DO.CustomerExeptions cexp)
            {
                throw new BLParcelExption($"Can't update the custumer because it dosn't exist");
            }
            mydale.UpdateCustomer(id, name, phone);
        }
        public void SendDroneToCharge(int id)
        {
            BO.Drone d;
            try
            {
                d = drones.FirstOrDefault(x => x.Id == id);  //bl צריך לחפש ברשימה של הרחפנים ב 
            }
            catch (DO.DroneExeptions dexp)
            {
                throw new BLDroneExption($"Can't send the drone to charge because it dosn't exist");
            }
            if (d.status != DroneStatus.Available)
            {
                throw new BLDroneExption($"Can't send the drone to charge because it is transfering a parcel");
            }
            double battery = d.Battery;
            DO.BaseStation s = DistanceToCharge(id, ref battery);  //the station to charge
            BO.Drone dr = drones.FirstOrDefault(x => x.Id == id);
            dr.Battery = battery;
            dr.location1.Latitude = s.Latitude;
            dr.location1.Longitude = s.Longitude;
            dr.status = DroneStatus.Maitenance;
            mydale.ChargeDrone(id, s.Id);

        }
         private DO.BaseStation DistanceToCharge(int id, ref double battery)
        {
            double dis = 0;
            double dla = toRadians(drones.FirstOrDefault(x => x.Id == id).location1.Latitude);
            double dlo = toRadians(drones.FirstOrDefault(x => x.Id == id).location1.Longitude);
            double km = 6371;
            double help;
            DO.BaseStation b = new DO.BaseStation();
            foreach (DO.BaseStation bs in mydale.DisplayAvailableStation())
            {
                double bsla = toRadians(bs.Latitude);
                double bslo = toRadians(bs.Longitude);
                help = km * (2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((dla - bsla) / 2), 2) +
                   Math.Cos(dla) * Math.Cos(bsla) *
                   Math.Pow(Math.Sin((dlo - bslo) / 2), 2))));
                if (dis == 0)
                {
                    dis = help;
                    b = bs;
                }
                else if (dis > help)
                {
                    dis = help;
                    b = bs;
                }
            }
            BO.Drone d = drones.FirstOrDefault(x => x.Id == id);//the battrey goes down 1% per km
            if (dis > d.Battery)
            {
                throw new BLDroneExption("drone cannot be charged its too not enough battery to get to station ");
            }
            battery = d.Battery - dis;
            return b;
        }
        private double toRadians(double deg)
        {
            return (deg * Math.PI) / 180;
        }

        public void DischargeDrone(int id, double time)
        {
            BO.Drone d = drones.FirstOrDefault(x => x.Id == id);
            if (d == null)
            {
                throw new BLDroneExption("the drone was not found");
            };

            if (d.status != DroneStatus.Maitenance)
            {
                throw new BLDroneExption("the drone was is not charging in the moment");
            }
            d.status = DroneStatus.Available;
            //double battery = mydale.returnChargerate() * 60 * time;
            //d.Battery += battery;
            mydale.DischargeDrone(id);
        }
        public void MatchDroneToParcel(int id)
        {
            BO.Drone d = drones.FirstOrDefault(x => x.Id == id);
            double battery = d.Battery;
            if (d.status != DroneStatus.Available)
            {
                throw new BLDroneExption("the drone isnt aviabale");
            }
            foreach (DO.Parcel P in mydale.DisplayParcelUnmatched())
            {
                if (P.priorty == DO.Priorities.Urgent && P.weight < (DO.Weights)d.MaxWeight)
                {
                    DO.BaseStation bsender = mydale.DisplayStation(P.SenderId);
                    Distance(d, bsender, ref battery);
                    DO.BaseStation breciver = mydale.DisplayStation(P.TargetId);
                    BO.Drone drone = new BO.Drone();
                    Distance(drone, breciver, ref battery);
                    double newbattery = battery;
                    DistanceToCharge(id, ref newbattery);
                    if (newbattery < d.Battery)// if there is enough battery to make the delivery and to charge if needed
                    {
                        d.status = DroneStatus.Shipment;
                        d.ParcelIntransfer.Id = P.Id;
                        d.ParcelIntransfer.status = false;// false=waiting for transfer
                        d.ParcelIntransfer.weight = (BO.Weights)P.weight;
                        d.ParcelIntransfer.Sender.Id = P.SenderId;
                        d.ParcelIntransfer.Sender.Id = mydale.DisplayStation(P.SenderId).Name;
                        d.ParcelIntransfer.Collection.Latitude = mydale.DisplayStation(P.SenderId).Latitude;
                        d.ParcelIntransfer.Collection.Longitude = mydale.DisplayStation(P.SenderId).Longitude;
                        d.ParcelIntransfer.CollectionDestination.Latitude = mydale.DisplayStation(P.TargetId).Latitude;
                        d.ParcelIntransfer.CollectionDestination.Longitude = mydale.DisplayStation(P.TargetId).Longitude;
                        d.ParcelIntransfer.TransportDistance = Distance(d, mydale.DisplayStation(P.SenderId), ref newbattery);
                        //all the changes needed in bl for the drone
                        mydale.UpdateParcelToDrone(id, P.Id);//updates changes in drone

                    }
                }
            }
        }
        private double Distance(BO.Drone d, DO.BaseStation s, ref double battery)// get the battery needed for that distance
        {
            double km = 6371;
            double dla = toRadians(d.location1.Latitude);
            double dlo = toRadians(d.location1.Longitude);
            double bla = toRadians(s.Latitude);
            double blo = toRadians(s.Longitude);
            double dis = km * (2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((dla - bla) / 2), 2) +
                    Math.Cos(dla) * Math.Cos(bla) *
                    Math.Pow(Math.Sin((dlo - blo) / 2), 2))));
            battery -= dis;
            return dis;

        }
        public void ParcelCollection(int Pid)
        {
            BO.Drone d = drones.FirstOrDefault(x => x.ParcelIntransfer.Id == Pid);
            double battery = d.Battery;
            DO.Parcel P = mydale.DisplayParcel(Pid);
            if (d.ParcelIntransfer.status == true)
            {
                throw new BLDroneExption("the parcel was allready picked up");
            }
            DO.BaseStation s = mydale.DisplayStation(d.ParcelIntransfer.Sender.Id);
            Distance(d, s, ref battery);
            d.Battery = battery;
            d.location1.Latitude = s.Latitude;
            d.location1.Longitude = s.Longitude;
            d.ParcelIntransfer.status = true;
            mydale.Parcelcollection(Pid, d.Id);
        }
        public void ParcelDelivery(int Pid)
        {
            BO.Drone d = drones.FirstOrDefault(x => x.ParcelIntransfer.Id == Pid);
            DO.Parcel P = mydale.DisplayParcel(Pid);
            if (d.ParcelIntransfer.status == false || P.Delivered != null)
            {
                throw new BLDroneExption("the parcel can't be delivered ");
            }
            d.Battery-=d.ParcelIntransfer.TransportDistance;
            d.location1 = d.ParcelIntransfer.CollectionDestination;
            mydale.ParcelDelivery(P.Id, P.TargetId);
        }




        /*מפה צריך לעשות את כל הפונקציות הבאות*/

        public IEnumerable DisplayBaseStationlst()
        {
            return mydale.DisplayStationList();
        }

        public IEnumerable DisplayDronelst(Func<BO.Drone, bool> predicate = null)
        {
        
            if (predicate != null)
            {
                return drones.Where(predicate);
            }
            else
            { 
                return drones; 
            }
        }

        public IEnumerable DisplayCustomerlst()
        {
            return mydale.DisplayCustomerList();
        }

        public IEnumerable DisplayParcellst(Predicate<DO.Parcel> p)
        {
            List<DO.Parcel> parcellst= new List<DO.Parcel>();
            if (p != null)
            {
                foreach(var item in mydale.DisplayParcelList())
                {
                    if (p((DO.Parcel)item))
                    {
                        parcellst.Add((DO.Parcel)item);
                    }
                }
                return parcellst.AsEnumerable();
            }
            else
            {
                return mydale.DisplayParcelList();
            }
          
        }

        public IEnumerable DisplayParcelsUnmatched(Predicate<BO.Parcel> p)
        {

            return mydale.DisplayParcelUnmatched((Predicate<DO.Parcel>)p);
        }

        public IEnumerable DisplayStationsToCharge(Predicate<BO.BaseStation> s)
        {
            return mydale.DisplayAvailableStation((Predicate<DO.BaseStation>) s);
        }


    }
}


