using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL.DO;


namespace DAL
{
    namespace DalObject
    {
         interface IDal
        {
            public int AddParcel(Parcel p);
            public void AddCustomer(Customer c);
            public void AddStation(ref BaseStation s);
            public void AddDrone(Drone d);
            public void UpdateParcelToDrone(int droneId, int parcleId);
            public void Parcelcollection(int p, int d);
            public void ParcelDelivery(int p, int c);
            public void ChargeDrone(int d, int s);
            public void DischargeDrone(int d);
            public void DisplayStation(int Id);
            public void DisplayDrone(int Id);
            public void DisplayCustomer(int Id);
            public void DisplayParcel(int Id);
            public void DisplayDroneList();
            public void DisplayStationList();
            public void DisplayCustomerList();
            public void DisplayParcelList();
            public void DisplayParcelUnmatched();
            public void DisplayAvailableStation();
            public double* PowerConsumptionRequest();


        }
    }
}
