using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using System.Collections;



namespace DalApi
{
    public interface IDal
    {
        public void AddParcel(Parcel p);
        public void AddCustomer(Customer c);
        public void AddStation(BaseStation s);
        public void AddDrone(Drone d);
        public void UpdateDrone(int id, String model);
        public void UpdateBaseStation(int id, int name, int chargeslots);
        public void UpdateParcelToDrone(int droneId, int parcleId);
        public void UpdateCustomer(int id, String name = "", String phone = "");
        public void UpdateParcel(Parcel p);
        public void Parcelcollection(int p, int d);
        public void ParcelDelivery(int p, int c);
        public void ChargeDrone(int d, int? s);
        public void DischargeDrone(int d);
        public BaseStation DisplayStation(int Id);
        public Drone DisplayDrone(int Id);
        public Customer DisplayCustomer(int Id);
        public Parcel DisplayParcel(int Id);
        public IEnumerable DisplayDroneList();
        public List<BaseStation> DisplayStationList(Func<BaseStation, bool> p=null);
        public IEnumerable DisplayCustomerList();
        public IEnumerable DisplayParcelList(Func<Parcel,bool> p=null);
        public IEnumerable DisplayParcelUnmatched(Predicate<Parcel> p=null);
        public IEnumerable DisplayAvailableStation(Predicate<BaseStation> p=null);
    }

}

