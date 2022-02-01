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
        public void AddCustomer(BO.Customer customer)
        {

            DO.Customer customer1 = new DO.Customer();
            customer1.Id = customer.Id;
            customer1.Name = customer.Name;
            customer1.Phone = customer.Phone.ToString();
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
            DO.BaseStation station = firstCharge();
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
                SendDroneToCharge(drone.Id, station.Id);
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
                weight = (BO.Weights)dalParcel.weight,
                priority = (BO.Priorities)dalParcel.priority,
                PickedUp = dalParcel.PickedUp,
                Scheduled = dalParcel.Scheduled,
                Requsted = dalParcel.Requsted,
                Delivered = dalParcel.Delivered
            };
            dr = drones.FirstOrDefault(x => x.Id == dalParcel.DroneId);
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
                Id = cust.Id,
                Name = cust.Name
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
            DO.Drone drone = new DO.Drone
            {
                Id = d.Id,
                Model = d.Model,
                MaxWeight = (DO.Weights)d.MaxWeight
            };
            try
            {
                mydale.UpdateDrone(drone);
            }
            catch (DO.IDNotExistsInTheSystem ex)
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


        /// <summary>
        /// the function that tries to send the drone to charge
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stationId"></param>
        public void SendDroneToCharge(int id, int stationId = 0)
        {
            if (stationId != null)
            {
                mydale.ChargeDrone(id, stationId);
                return;
            }
            var d = drones.FirstOrDefault(x => x.Id == id);  //bl צריך לחפש ברשימה של הרחפנים ב 
            if (d.status != BO.DroneStatus.Available)
            {
                throw new BLDroneExption($"Can't send the drone to charge because it is transfering a parcel");
            }
            double battery = d.Battery;
            DO.BaseStation s = Getcloseststation(id, ref battery,d);  //the station to charge
            d.Battery = battery;
            d.location1.Latitude = s.Latitude;
            d.location1.Longitude = s.Longitude;
            d.status = BO.DroneStatus.Maitenance;
            mydale.ChargeDrone(id, s.Id);

        }

        private DO.BaseStation Getcloseststation(int id, ref double battery,BO.Drone D)
        {
            double dis = 0;
            double x1 = D.location1.Latitude;
            double y1 = D.location1.Longitude;
            double help;
            DO.BaseStation b = new DO.BaseStation();
            foreach (DO.BaseStation bs in mydale.DisplayAvailableStation())
            {
                double x2 = bs.Latitude;
                double y2 = bs.Longitude;
                help = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
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
            if (dis/3 > d.Battery)
            {
                throw new BLDroneExption("drone cannot be charged its too not enough battery to get to station ");
            }
            battery = d.Battery - dis/3;
            return b;
        }


        public void DischargeDrone(int id, double n)
        {
            var d = drones.FirstOrDefault(x => x.Id == id);
            if (d == null)
            {
                throw new BLDroneExption("the drone was not found");
            };

            if (d.status != BO.DroneStatus.Maitenance)
            {
                throw new BLDroneExption("the drone was is not charging in the moment");
            }
            d.status = BO.DroneStatus.Available;
            DO.DroneCharge dr = mydale.DisplayDroneCharge(id);
            if (d.Battery + (n * 60) > 100)
            {
                d.Battery = 100;
            }
            else
            {
                d.Battery += n * 60;
            }
            mydale.DischargeDrone(id);
        }
        public int MatchDroneToParcel(int id)
        {
            var d = drones.FirstOrDefault(x => x.Id == id);
            List<DO.Parcel> p1 = new List<DO.Parcel>();
            List<DO.Parcel> p2 = new List<DO.Parcel>();
            List<DO.Parcel> p3 = new List<DO.Parcel>();
            double battery = d.Battery; // to check if there is a battery for a round trip
            if (d.status == BO.DroneStatus.Shipment)
            {
                throw new BLDroneExption("the drone isnt aviabale");
            }
            if(d.status== BO.DroneStatus.Maitenance)
            {
                double t = 1;
                DischargeDrone(id,t);
            }
            foreach (DO.Parcel P in mydale.DisplayParcelList())
            {
                if (P.DroneId == 0)
                {
                    if (P.priority == DO.Priorities.Urgent)
                    {
                        p1.Add(P);
                    }
                    else if (P.priority == DO.Priorities.Fast)
                    {
                        p2.Add(P);
                    }
                    else
                    {
                        p3.Add(P);
                    }
                }
            }

            foreach (DO.Parcel P in mydale.DisplayParcelList(x=>x.DroneId==0))
            {
                if (P.weight <= (DO.Weights)d.MaxWeight) {
                    if (P.priority == DO.Priorities.Urgent || p1.Count == 0 && P.priority == DO.Priorities.Fast
                        || p1.Count == 0 && p2.Count == 0 && P.priority == DO.Priorities.Normal)
                    {
                        DO.Customer Csender = mydale.DisplayCustomer(P.SenderId);
                        Distance(d.location1, Csender, ref battery); // if it can get to the sender
                        DO.Customer Creciver = mydale.DisplayCustomer(P.TargetId);
                        Location l = new Location { Latitude = Csender.Latitude,Longitude=Csender.Longitude };
                        Distance(l, Creciver, ref battery);
                        double b = battery;
                        Getcloseststation(id, ref b,d);
                        if (0 < b)// if there is enough battery to make the delivery and to charge if needed
                        {
                            d.status = BO.DroneStatus.Shipment;
                            d.Battery -= battery;
                            ParcelInTransfer tr = new ParcelInTransfer
                            {
                                Id = P.Id,
                                status = false,// false=waiting for transfer
                                weight = (BO.Weights)P.weight,
                                Sender = new CustomerParcel
                                {
                                    Id = P.SenderId,
                                    Name = mydale.DisplayCustomer(P.SenderId).Name
                                },
                                getting = new CustomerParcel
                                {
                                    Id = P.TargetId,
                                    Name = mydale.DisplayCustomer(P.TargetId).Name
                                },
                                Collectionstart=new Location
                                {
                                    Latitude = mydale.DisplayCustomer(P.SenderId).Latitude,
                                    Longitude = mydale.DisplayCustomer(P.SenderId).Longitude
                                },
                                CollectionDestination= new Location
                                {
                                    Latitude = mydale.DisplayCustomer(P.TargetId).Latitude,
                                    Longitude = mydale.DisplayCustomer(P.TargetId).Longitude
                                },
                                TransportDistance = Distance(d.location1, mydale.DisplayCustomer(P.SenderId), ref battery)

                            };
                            d.ParcelIntransfer = tr;
                            mydale.UpdateParcelToDrone(id, P.Id);//updates changes in drone
                            return P.Id;
                        }
                    }
                }
            }
            return -1;
        }
        private double Distance(Location d, DO.Customer c, ref double battery)// get the battery needed for that distance
        {
            double x1 = d.Latitude;
            double y1 = d.Longitude;
            double x2 = c.Latitude;
            double y2 = c.Longitude;
            double dis = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            battery -= dis/3;// every 3 km is 1%
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
            DO.Customer s = mydale.DisplayCustomer(d.ParcelIntransfer.Sender.Id);
            Distance(d.location1, s, ref battery);
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
            List<DO.BaseStation> b = new List<DO.BaseStation>();
            foreach(DO.BaseStation item in mydale.DisplayAvailableStation())
            {
                b.Add(item);
            }
            DO.BaseStation station=null;
            try
            {
                station=b.FirstOrDefault();
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
            IEnumerable oldlst = mydale.DisplayParcelList(predicate);
            List<BO.ParcelToList> newlst = new List<BO.ParcelToList>();
            foreach (DO.Parcel item in oldlst)
            {
                newlst.Add(new ParcelToList
                {
                    Id = item.Id,
                    SenderId = item.SenderId,
                    TargetId = item.TargetId,
                    weight = (BO.Weights?)item.weight,
                    priority = (BO.Priorities?)item.priority,
                    status = BO.Status.Defined
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
            return mydale.DisplayAvailableStation();
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


