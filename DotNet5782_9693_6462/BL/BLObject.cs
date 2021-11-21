using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using IBL.BO;


namespace IBL
{
    public class BLObject
    {
        private List<IBL.BO.Drone> drones;
        IDAL.DO.IDal mydale;
        private object l;

        public BLObject()
        {
            mydale = new DalObject.DalObject();
            drones = new List<IBL.BO.Drone>();
        }
        public void AddCustomer(Customer customer)
        {
            IDAL.DO.Customer customer1 = new IDAL.DO.Customer();
            customer1.Id = customer.Id;
            customer1.Name = customer.Name;
            customer1.Phone = customer.Phone;
            customer1.Latitude = customer.location.Latitude;
            customer1.Longitude = customer.location.Longitude;
            mydale.AddCustomer(customer1);

        }
        public void AddDrone(Drone drone)
        {
            Random r = new Random();
            IDAL.DO.Drone drone1 = new IDAL.DO.Drone();
            drone1.Id = drone.Id;
            drone1.Model = drone.Model;
            drone1.MaxWeight = (IDAL.DO.Weights)drone.MaxWeight;
            drone.Battery = r.Next(20, 41);
            drone.status = DroneStatus.Maitenance;
            drones.Add(drone);


        }
        public void AddParcel(Parcel parcel)
        {
            IDAL.DO.Parcel parcel1 = new IDAL.DO.Parcel();
            parcel1.SenderId = parcel.Sender.Id;
            parcel1.TargetId = parcel.Getting.Id;
            parcel1.weight = (IDAL.DO.Weights)parcel.weight;
            parcel1.priorty = (IDAL.DO.Priorities)parcel.priority;
            parcel1.Requsted = parcel.Requsted;
            parcel1.Scheduled = parcel.Scheduled;
            parcel1.PickedUp = parcel.PickedUp;
            parcel1.Delivered = parcel.Delivered;
            parcel1.DroneId = parcel.droaneParcel.Id;
            mydale.AddParcel(parcel1);
        }

        public void AddBaseStation(BaseStation baseStation)
        {
            IDAL.DO.BaseStation baseStation1 = new IDAL.DO.BaseStation();
            baseStation1.Id = baseStation.Id;
            baseStation1.Name = baseStation.Name;
            baseStation1.Latitude = baseStation.location.Latitude;
            baseStation1.Longitude = baseStation.location.Longitude;
            baseStation1.ChargeSlots = baseStation.AvailableChargingStations;
            baseStation.DroneInChargings = baseStation.DroneInChargings;
        }
        public Customer GetCustomer(int id)
        {
            Customer customer = default;
            try
            {
                IDAL.DO.Customer dalCustomper = mydale.DisplayCustomer(id);
            }
            catch (IDAL.DO.CustomerExeptions custEx)
            {
                throw new BLCustomerExption($"Customer id {id} was not found", custEx);
            }

            return customer;
        }


        public Drone GetDrone(int id)
        {
            Drone d = new Drone();
            if (drones.Exists(drone => drone.Id != id))
            {
                throw new BLDroneExption($"drone {id} was not found");
            }
            for (int i = 0; i < drones.Count; i++)
            {
                if (drones[i].Id == id)
                {
                    d = drones[i];
                }
            }
            return d;
        }

        public void UpdateDrone(int id, String model)
        {

            try
            {
                mydale.DisplayDrone(id);
            }
            catch (IDAL.DO.DroneExeptions dexp)
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
            catch (IDAL.DO.BaseStationExeptions bexp)
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
            catch (IDAL.DO.CustomerExeptions cexp)
            {
                throw new BLCustomerExption($"Can't update the custumer because it dosn't exist");
            }
            mydale.UpdateCustomer(id, name, phone);
        }
        public void SendDroneToCharge(int id)
        {
            Drone d;
            try
            {
                d = GetDrone(id);     //bl צריך לחפש ברשימה של הרחפנים ב 
            }
            catch (IDAL.DO.DroneExeptions dexp)
            {
                throw new BLDroneExption($"Can't send the drone to charge because it dosn't exist");
            }
            if (d.status != DroneStatus.Available)
            {
                throw new BLDroneExption($"Can't send the drone to charge because it is transfering a parcel");
            }
            double battery = d.Battery;
            IDAL.DO.BaseStation s = DistanceToBattery(id, ref battery);  //the station to charge
            Drone dr = drones.FirstOrDefault(x => x.Id == id);
            dr.Battery = battery;
            dr.location1.Latitude = s.Latitude;
            dr.location1.Longitude = s.Longitude;
            dr.status = DroneStatus.Maitenance;
            mydale.ChargeDrone(id, s.Id);

        }
        private IDAL.DO.BaseStation DistanceToBattery(int id, ref double battery)
        {
            double dis = 0;
            double dla = toRadians(drones.FirstOrDefault(x => x.Id == id).location1.Latitude);
            double dlo = toRadians(drones.FirstOrDefault(x => x.Id == id).location1.Longitude);
            double km = 6371;
            double help;
            IDAL.DO.BaseStation b = new IDAL.DO.BaseStation();
            foreach (IDAL.DO.BaseStation bs in mydale.DisplayAvailableStation())
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
            Drone d = drones.FirstOrDefault(x => x.Id == id);//the battrey goes down 1% per km
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
            Drone d = new Drone();
            try
            {
                d = drones.Find(x => x.Id == id);
            }
            catch (IBL.BO.BLDroneExption dexp)
            {
                throw new BLDroneExption("the drone was not found");
            }
            if (d.status != DroneStatus.Maitenance)
            {
                throw new BLDroneExption("the drone was is not charging in the moment");
            }
            d.status = DroneStatus.Available;
            double battery = mydale.returnChargerate() * 60 * time;
            d.Battery += battery;
            mydale.DischargeDrone(id);
        }
        public void MatchDroneToParcel(int id)
        {
            Drone d = drones.FirstOrDefault(x => x.Id == id);
            double battery = d.Battery;
            if (d.status != DroneStatus.Available)
            {
                throw new BLDroneExption("the drone isnt aviabale");
            }
            foreach (IDAL.DO.Parcel P in mydale.DisplayParcelUnmatched())
            {
                if (P.priorty == IDAL.DO.Priorities.Urgent && P.weight < (IDAL.DO.Weights)d.MaxWeight)
                {
                    IDAL.DO.BaseStation bsender = mydale.DisplayStation(P.SenderId);
                    distance(d, bsender, ref battery);
                    IDAL.DO.BaseStation breciver = mydale.DisplayStation(P.TargetId);
                    Drone drone = new Drone();
                    drone.location1.Latitude = bsender.Latitude;
                    drone.location1.Longitude = bsender.Longitude;
                    distance(drone, breciver, ref battery);
                    if (battery < d.Battery)// if there is enough battery to make the delivery then check if there is a way to charge if needed
                    {

                    }
                }
            }
        }
        public void distance(Drone d, IDAL.DO.BaseStation s, ref double battery)// get the battery needed for that distance
        {
            double km = 6371;
            double dla = toRadians(d.location1.Latitude);
            double dlo = toRadians(d.location1.Longitude);
            double bla = toRadians(s.Latitude);
            double blo = toRadians(s.Longitude);
            double help = km * (2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin((dla - bla) / 2), 2) +
                    Math.Cos(dla) * Math.Cos(bla) *
                    Math.Pow(Math.Sin((dlo - blo) / 2), 2))));
            battery -= help;

        }

    }
}


