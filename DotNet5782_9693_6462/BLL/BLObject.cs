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
using System.Xml.Linq;
using NPOI.SS.Formula.Functions;


public interface IEnumerable<out list> : IEnumerable
{
    IEnumerable<list> GetEnumerable();
}
namespace BLObject
{
    public sealed class BLObject : IBl
    {
        #region constructers
        static readonly IBl instance = new BLObject();
        public static IBl Instance { get => instance; }
        public ObservableCollection<BO.Drone> drones;
        internal IDal mydale = DalFactory.GetDal();
        public Random rand = new Random();
        public BLObject() // היה פריווט והחלפנו לפבליק כדי שיעבוד
        {
            drones = new ObservableCollection<BO.Drone>();

        }
        #endregion

        #region Add methods
        public void AddCustomer(BO.CustomerList customer)
        {

            DO.Customer customer1 = new DO.Customer();
            customer1.Id = customer.Id;
            customer1.Name = customer.Name;
            customer1.Phone = customer.Phone.ToString();
            //customer1.Latitude = customer.location.Latitude;
            //customer1.Longitude = customer.location.Longitude;
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
            DO.BaseStation station=firstCharge();
            DO.Drone drone1 = new DO.Drone();
            BO.Location l = new Location();
            l.Latitude = station.Latitude;
            l.Longitude = station.Longitude;
            drone1.Id = drone.Id;
            drone1.Model = drone.Model;
            drone1.MaxWeight = (DO.Weights)drone.MaxWeight;
            drone.Battery = rand.Next(20, 41);
            drone.location1 = l;
            if (station != null)
            {
                drone.status = BO.DroneStatus.Maitenance;
            }
            drones.Add(drone);
            mydale.AddDrone(drone1);
            try
            {
                SendDroneToCharge(drone.Id,station.Id);
            }
            catch
            {
               // throw  "couldnt charge";
            }
        }
        public void AddParcel(BO.ParcelToList parcel)
        {
            DO.Parcel newparcel = new DO.Parcel();
            newparcel.Id = parcel.Id;
            newparcel.SenderId = parcel.SenderId;
            newparcel.TargetId = parcel.TargetId;
            newparcel.priority = (DO.Priorities)parcel.priority;
            newparcel.weight = (DO.Weights)parcel.weight;
            newparcel.Requsted = DateTime.Now;
            newparcel.Scheduled = new DateTime(0001, 01, 01, 00, 00, 00);
            newparcel.Delivered = new DateTime(0001, 01, 01, 00, 00, 00);
            newparcel.PickedUp = new DateTime(0001, 01, 01, 00, 00, 00);
            mydale.AddParcel(newparcel);
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
        #endregion

        #region Get item methods
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

            if (d == null)
            {
                throw new BLDroneExption($"drone {id} was not found");
            }
            return d;
        }
        public BO.Parcel GetParcel(int id)
        {
            BO.Parcel parcel = default;
            DO.Parcel dalParcel = new DO.Parcel();
            BO.Drone dr = new BO.Drone();
            DO.Customer cust = new DO.Customer();
            try
            {
                dalParcel = mydale.DisplayParcel(id);
            }
            catch (DO.ParcelExeptions custEx)
            {
                throw new BLParcelExption($"Parcel id {id} was not found", custEx);
            }
            parcel = new BO.Parcel
            {
                Id = dalParcel.Id,
                weight= (BO.Weights)dalParcel.weight,
                priority= (BO.Priorities)dalParcel.priority,
                PickedUp=dalParcel.PickedUp,
                Scheduled=dalParcel.Scheduled,
                Requsted=dalParcel.Requsted,
                Delivered=dalParcel.Delivered
            };
            dr = drones.FirstOrDefault(x=>x.Id==dalParcel.DroneId);
            if (dr != null)
            {
                parcel.droneParcel = new DroneParcel
                {
                    Id = dr.Id,
                    BatteryStatus = dr.Battery,
                    Location = dr.location1
                };
            }
            cust = mydale.DisplayCustomer(dalParcel.SenderId);
            parcel.Sender = new CustomerParcel
            {
                Id=cust.Id,
                Name=cust.Name
            };
            cust = mydale.DisplayCustomer(dalParcel.TargetId);
            parcel.Getting = new CustomerParcel
            {
                Id = cust.Id,
                Name = cust.Name
            };
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

        #endregion
        public void UpdateDrone(BO.Drone d)
        {
            DO.Drone drone=new DO.Drone{
            Id = d.Id,
            Model = d.Model,
            MaxWeight= (DO.Weights)d.MaxWeight
        };
            try
            {
                mydale.UpdateDrone(drone);
            }
            catch(DO.IDNotExistsInTheSystem ex)
            {
                throw new BO.DroneExistsException("exp", ex);
            }
            
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

        public void UpdateParcel(BO.ParcelToList p)
        {
            DO.Parcel P = new DO.Parcel
            {
                Id = p.Id,
                priority = (DO.Priorities?)p.priority,
                TargetId = p.TargetId
            };
            mydale.UpdateParcel(P);
        }



        public void SendDroneToCharge(int id,int? stationId=null)
        {
            if (stationId != null)
            {
                mydale.ChargeDrone(id, stationId);
                return;
            }
            BO.Drone d;
            try
            {
                d = drones.FirstOrDefault(x => x.Id == id);  //bl צריך לחפש ברשימה של הרחפנים ב 
            }
            catch (DO.DroneExeptions dexp)
            {
                throw new BLDroneExption($"Can't send the drone to charge because it dosn't exist");
            }
            if (d.status != BO.DroneStatus.Available)
            {
                throw new BLDroneExption($"Can't send the drone to charge because it is transfering a parcel");
            }
            double battery = d.Battery;
            DO.BaseStation s = DistanceToCharge(id, ref battery);  //the station to charge
            BO.Drone dr = drones.FirstOrDefault(x => x.Id == id);
            dr.Battery = battery;
            dr.location1.Latitude = s.Latitude;
            dr.location1.Longitude = s.Longitude;
            dr.status = BO.DroneStatus.Maitenance;
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

            if (d.status != BO.DroneStatus.Maitenance)
            {
                throw new BLDroneExption("the drone was is not charging in the moment");
            }
            d.status = BO.DroneStatus.Available;
            //double battery = mydale.returnChargerate() * 60 * time;
            //d.Battery += battery;
            mydale.DischargeDrone(id);
        }
        public int MatchDroneToParcel(int id)
        {
            BO.Drone d = drones.FirstOrDefault(x => x.Id == id);
            double battery = d.Battery;
            if (d.status != BO.DroneStatus.Available)
            {
                throw new BLDroneExption("the drone isnt aviabale");
            }
            foreach (DO.Parcel P in mydale.DisplayParcelUnmatched())
            {
                if (P.priority == DO.Priorities.Urgent && P.weight < (DO.Weights)d.MaxWeight)
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
                        d.status = BO.DroneStatus.Shipment;
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
                        return P.Id;
                    }
                }
            }
            return -1;
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
            d.Battery -= d.ParcelIntransfer.TransportDistance;
            d.location1 = d.ParcelIntransfer.CollectionDestination;
            mydale.ParcelDelivery(P.Id, P.TargetId);
        }

        private DO.BaseStation firstCharge()
        {
            DO.BaseStation station;
            try
            {
                station = (from s in mydale.DisplayStationList()
                           where s.ChargeSlots > 0
                           select new DO.BaseStation()
                           {
                               Id = s.Id,
                               Name = s.Name,
                               Latitude = s.Latitude,
                               Longitude = s.Longitude,
                               ChargeSlots = s.ChargeSlots
                           }).FirstOrDefault();
            }
            catch
            {
                station = null;
            }

            return station;
        }


        public IEnumerable DisplayBaseStationlst(Func<DO.BaseStation, bool> predicate)
        {
            return mydale.DisplayStationList();
        }

        public IEnumerable DisplayDronelst(Func<BO.Drone, bool> predicate = null)
        {
            if (drones.Count() == 0)
            {
                initlizedronelist();
            }
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
        public delegate object Mydelegate(dynamic target);

        public IEnumerable DisplayParcellst(Func<DO.Parcel, bool> predicate)
        {
            IEnumerable oldlst= mydale.DisplayParcelList(predicate);
            List<BO.ParcelToList> newlst=new List<BO.ParcelToList>();
            foreach (DO.Parcel item in oldlst)
            {
                newlst.Add(new ParcelToList
                {
                    Id = item.Id,
                    SenderId = item.SenderId,
                    TargetId=item.TargetId,
                    weight= (BO.Weights?)item.weight,
                    priority = (BO.Priorities?)item.priority,
                    status= BO.Status.Defined
                });
            }
            return newlst.ToList();
        }

        public IEnumerable DisplayParcelsUnmatched(Predicate<BO.Parcel> p)
        {
            return mydale.DisplayParcelUnmatched((Predicate<DO.Parcel>)p);
        }

        public IEnumerable DisplayStationsToCharge(Predicate<BO.BaseStation> s)
        {
            return mydale.DisplayAvailableStation((Predicate<DO.BaseStation>)s);
        }
        private void initlizedronelist() //saves all the drones saved in dal to bl drone list
        {
            foreach (DO.Drone dr in mydale.DisplayDroneList())
            {
                DO.BaseStation station = firstCharge();
                BO.Location l = new Location();
                l.Latitude = station.Latitude;
                l.Longitude = station.Longitude;
                drones.Add(new BO.Drone()
                {
                    Id = dr.Id,
                    Model = dr.Model,
                    MaxWeight = (BO.Weights)dr.MaxWeight,
                    location1 = l,
                    status = BO.DroneStatus.Maitenance,
                    Battery = rand.Next(20, 40)
                });
                try
                {
                    SendDroneToCharge(dr.Id, station.Id);
                }
                catch
                {
                    // throw  "couldnt charge";
                }
            }
        }

    }
}


