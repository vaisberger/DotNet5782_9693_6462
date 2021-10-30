using System;


namespace DalObject
{
    public class DalObject
    {
        public static void AddCustomer(IDAL.DO.Customer c)
        {
            DataSource.customers.Add(c);
        }
        public static void AddStation(IDAL.DO.BaseStation b)
        {
            DataSource.station.Add(b);
        }



        public static void DisplayStation(int Id)
        {
            DataSource.station.Find(x => x.Id == Id).ToString();
        }
        public static void DispalyDrone(int Id)
        {
            DataSource.drones.Find(x => x.Id == Id).ToString();
        }
        public static void DisplayCostomer(int Id)
        {
            DataSource.customers.Find(x => x.Id == Id).ToString();
        }
        public static void DisplayParcel(int Id)
        {
            DataSource.parcels.Find(x => x.Id == Id).ToString();

        }

    }
}
