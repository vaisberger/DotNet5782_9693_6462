using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BLObject;

    namespace IBL.BO
    {
        public interface IBl
        {
            public void AddDrone(Drone drone);
            public void AddCustomer(Customer customer);
            public void AddParcel(Parcel parcel);
            public void AddBaseStation(BaseStation baseStation);

            public Customer GetCustomer(int id);
            public Drone GetDrone(int id);
            public Parcel GetParcel(int id);
            public BaseStation GetBaseStation(int id);

            public void UpdateBaseStation(int id, int name = -1, int chargeslots = -1);
            public void UpdateDrone(int id, String model);
            public void UpdateCustomer(int id, String name = "", String phone = "");

            public void SendDroneToCharge(int id);
            public void DischargeDrone(int id, double time);
            public void MatchDroneToParcel(int id);
            public void ParcelCollection(int Pid);
            public void ParcelDelivery(int Pid);

            public IEnumerable DisplayBaseStationlst();  //   צריך להחזיר רשימה שתודפס לסיים את זה  להחזיר בפונקציות 
            public IEnumerable DisplayDronelst();
            public IEnumerable DisplayCustomerlst();
            public IEnumerable DisplayParcellst();
            public IEnumerable DisplayParcelsUnmatched(); // רשימה של חבילות שלא שוייכו
            public IEnumerable DisplayStationsToCharge(); // רשימה של תחנות שעדיין לא שוייכו

        }
    }


