using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BLObject;
using BO;


namespace BLApi
{
    public interface IBl
    {
        public void AddDrone(Drone drone);
        public void AddCustomer(Customer customer);
        public void AddParcel(ParcelToList p);
        public void AddBaseStation(BaseStation baseStation);

        public Customer GetCustomer(int id);
        public Drone GetDrone(int id);
        public Parcel GetParcel(int id);
        public BaseStation GetBaseStation(int id);

        public void UpdateBaseStation(int id, int name = -1, int chargeslots = -1);
        public void UpdateDrone(Drone d);
        public void UpdateCustomer(int id, String name = "", String phone = "");
        public void UpdateParcel(BO.ParcelToList p);

        public void SendDroneToCharge(int id, int stationid = 0);
        public void DischargeDrone(int id, DateTime time);

        public int MatchDroneToParcel(int id);
        public void ParcelCollection(int Pid);
        public void ParcelDelivery(int Pid);

        public IEnumerable DisplayBaseStationlst(Func<DO.BaseStation, bool> p = null);  //   צריך להחזיר רשימה שתודפס לסיים את זה  להחזיר בפונקציות 
        public IEnumerable DisplayDronelst(Func<Drone, bool> predicate = null);
        public IEnumerable DisplayCustomerlst();
        public IEnumerable DisplayParcellst(Func<DO.Parcel, bool> p = null);
        public IEnumerable DisplayParcelsUnmatched(Predicate<BO.Parcel> p = null); // רשימה של חבילות שלא שוייכו                                                               
        public IEnumerable DisplayStationsToCharge(Predicate<BO.BaseStation> s = null);
       
    }
}


