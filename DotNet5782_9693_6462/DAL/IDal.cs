using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.DO;
using System.Collections;
using DalObject;



    namespace IDAL.DO
    {
        public interface IDal
        {
            public int AddParcel(Parcel p);
            public void AddCustomer(Customer c);
            public void AddStation( BaseStation s);
            public void AddDrone(Drone d);
            public void UpdateParcelToDrone(int droneId, int parcleId);
            public void Parcelcollection(int p, int d);
            public void ParcelDelivery(int p, int c);
            public void ChargeDrone(int d, int s);
            public void DischargeDrone(int d);
            public BaseStation DisplayStation(int Id);
            public Drone DisplayDrone(int Id);
            public Customer DisplayCustomer(int Id);
            public Parcel DisplayParcel(int Id);
            public IEnumerable DisplayDroneList();
            public IEnumerable DisplayStationList();
            public IEnumerable DisplayCustomerList();
            public IEnumerable DisplayParcelList();
            public IEnumerable DisplayParcelUnmatched();
            public IEnumerable DisplayAvailableStation();
            public double[] PowerConsumptionRequest();


        }
    
    }

