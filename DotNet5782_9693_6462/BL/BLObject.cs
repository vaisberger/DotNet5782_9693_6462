using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBL.BO;


namespace IBL
{
    public class BLObject
    {
        private List<IBL.BO.Drone> drones;
        IDAL.DO.IDal mydale;
        public BLObject()
        {
            mydale = new DalObject.DalObject();
            drones = new List<IBL.BO.Drone>();
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
            Drone drone = default;
            try
            {
                IDAL.DO.Drone dalDrone = mydale.DisplayDrone(id);
            }
            catch (IDAL.DO.DroneExeptions cus)
            {
                throw new BLDroneExptions($"Drone id {id} was not found", cus);
            }
            return drone;
        }

        /*public BaseStation GetBaseStation(int id)
        {
            BaseStation baseStation = default;
        public Drone GetDrone(int id)
        {
            Drone d = new Drone();
            if (drones.Exists(drone => drone.Id != id))
            {
                throw new BLDroneExption($"station {id} dosen't exists ");
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

            try
            {
                IDAL.DO.BaseStation dalStation = mydale.DisplayStation(id);
            }
            catch (IDAL.DO.BaseStationExeptions bex)
            {
                throw new BLBaseStationException(bex.Message + "from dal");
            }
            return new BO.BaseStation
            {
                Id = dalStation.Id,
                Name=dalStation.Name,

            }
        }
        */

        /*public void UpdateDrone(int id, String model)
        {

            try {
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


        public void UpdateCustomer(int id, String name="", String phone = "")
        {
            try
            {
                mydale.DisplayCustomer(id);
            }
            catch (IDAL.DO.CustomerExeptions cexp)
            {
                throw new BLCustomerExption($"Can't update the custumer because it dosn't exist");
            }
            mydale.UpdateCustomer(id, name,phone);
        }
          public void SendDroneToCharge(int id)
        {
            Drone d;
            try
            {
               d= GetDrone(id);     //bl צריך לחפש ברשימה של הרחפנים ב 
            }
            catch (IDAL.DO.DroneExeptions dexp)
            {
                throw new BLDroneExption($"Can't send the drone to charge because it dosn't exist");
            }
            if (d.status!=DroneStatus.Available)
            {
                throw new BLDroneExption($"Can't send the drone to charge because it is transfering a parcel");
            }
            BaseStation s = DistanceToBattery(id);
            if (s!=null)
            {

            }

        }
        private BaseStation DistanceToBattery(int id)
        {
            double dla = toRadians(drones.FirstOrDefault(x => x.Id == id).location1.Latitude);
            double dlo= toRadians(drones.FirstOrDefault(x => x.Id == id).location1.Longitude);
            foreach (IDAL.DO.BaseStation bs in mydale.DisplayAvailableStation())
            {
                double bsla = toRadians(bs.Latitude);
                double bslo = toRadians(bs.Longitude);


            }
            return null;
        }
        private double toRadians(double deg)
        {
            return (deg * Math.PI) / 180;
        }
    }
}

